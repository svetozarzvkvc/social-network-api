using SocialNetwork.Application.UseCases.Commands.Categories;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.Application.UseCases.Queries.Posts;
using SocialNetwork.Application;
using SocialNetwork.Implementation.Logging.UseCases;
using SocialNetwork.Implementation.UseCases.Commands.Categories;
using SocialNetwork.Implementation.UseCases.Commands.Users;
using SocialNetwork.Implementation.Validators;
using SocialNetwork.Implementation;
using System.IdentityModel.Tokens.Jwt;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.Application.UseCases.Queries.Categories;
using SocialNetwork.Implementation.UseCases.Commands.Posts;
using SocialNetwork.Implementation.UseCases.Queries;
using SocialNetwork.Application.UseCases.Commands.Comments;
using SocialNetwork.Implementation.UseCases.Commands.Comments;
using static SocialNetwork.Implementation.UseCases.Queries.EfSearchPostsQuery;

namespace SocialNetwork.API.Core
{
    public static class ContainerExtensions 
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<CreateCategoryDtoValidator>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
            services.AddTransient<RegisterUserDtoValidator>();
            
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();

            
            services.AddTransient<UpdateCategoryDtoValidator>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();


            services.AddTransient<UpdatePostDtoValidator>();
            services.AddTransient<IUpdatePostCommand, EfUpdatePostCommand>();


            services.AddTransient<CreatePostDtoValidator>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();

            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();


            services.AddTransient<ISearchPostsQuery, AutomapperSearchPostsQuery>();

            services.AddTransient<ISearchCategoriesQuery, EfSearchCategoriesQuery>();

            services.AddTransient<CreateCommentDtoValidator>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();

            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IRejectUserRequestCommand, EfRejectUserRequestCommand>();

            services.AddTransient<UpdateCommentDtoValidator>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();

            services.AddTransient<IAddUserRelationCommand, EfAddUserRelationCommand>();
            services.AddTransient<IAcceptUserRequestCommand, EfAcceptUserRequestCommand>();
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
