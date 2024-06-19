﻿using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.Mail;
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
        private readonly RegisterUserDtoValidator _validator;
        private readonly IEmailService _emailService;

        public EfRegisterUserCommand(DatabaseContext context, RegisterUserDtoValidator validator, IEmailService emailService)
            : base(context)
        {
            _validator = validator;
            _emailService = emailService;
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
                Path = "/images/DefaultUser.png",
                UseCases = new List<UserUseCase>()
                {
                    new UserUseCase { UseCaseId = 1 },
                    new UserUseCase { UseCaseId = 3 }
                },
                UserCarts = new List<UserCart>()
                {
                    new UserCart()
                }
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            try
            {
                var emailSubject = "Welcome to AspProjekat2024!";
                var emailBody = $"Dear {user.FirstName},\n\nThank you for registering with us.\n\nBest regards,\nAspProjekat2024 Team";
                _emailService.SendEmailAsync(user.Email, emailSubject, emailBody).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}
