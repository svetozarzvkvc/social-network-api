using SocialNetwork.Application;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation;
using SocialNetwork.API;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Implementation.Validators;
using SocialNetwork.Application.UseCases.Commands.Categories;
using SocialNetwork.Implementation.UseCases.Commands.Categories;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.Implementation.UseCases.Commands.Users;
using SocialNetwork.Implementation.Logging.UseCases;
using System.Data;
using Microsoft.Data.SqlClient;
using SocialNetwork.Implementation.UseCases.Commands.Posts;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.Implementation.UseCases.Queries;
using SocialNetwork.Application.UseCases.Queries.Posts;
using SocialNetwork.Application.UseCases.Queries.Categories;
using SocialNetwork.API.Core;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();
builder.Configuration.Bind(settings);

builder.Services.AddSingleton(settings.Jwt);
builder.Services.AddAutoMapper(typeof(UseCaseInfo).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddTransient<SocialNetworkContext>(x => new SocialNetworkContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));
builder.Services.AddHangfire(config => config.UseSqlServerStorage(settings.HfConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();
builder.Services.AddUseCases();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<SocialNetworkContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddScoped<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }
    return x.GetService<IApplicationActorProvider>().GetActor();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }

            return Task.CompletedTask;

        }
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
