using FluentValidation;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using SocialNetwork.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Commands.Users
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        public int Id => 2;

        public string Name => "UserRegistration";

        private SocialNetworkContext _context;
        private RegisterUserDtoValidator _validator;

        public EfRegisterUserCommand(SocialNetworkContext context, RegisterUserDtoValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(RegisterUserDto data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {
                BirthDate = data.BirthDate.Value,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Image = _context.Files.FirstOrDefault(x => x.Path.Contains("default")),
                UserName = data.Username,
                Role = _context.Roles.FirstOrDefault(x=>x.Name == "User"),
            };

            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}
