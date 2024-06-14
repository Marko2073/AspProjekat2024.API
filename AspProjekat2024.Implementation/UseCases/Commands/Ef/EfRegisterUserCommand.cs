using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        

        public int Id => 5;

        public string Name => "Register User";

        public string Description => "User registration";

        private RegisterUserDtoValidator _validator;

        public EfRegisterUserCommand(DatabaseContext context, RegisterUserDtoValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(RegisterUserDto data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Phone = data.Phone,
                Address = data.Address,
                City = data.City,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Path = data.Path,
                
                UseCases = new List<UserUseCase>()
                {
                    new UserUseCase { UseCaseId = 1 },
                    new UserUseCase { UseCaseId = 3 }
                }

            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
