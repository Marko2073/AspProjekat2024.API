﻿using AspProjekat2024.Application.Logging;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation.Logging;
using AspProjekat2024.Implementation.UseCases.Commands.Ef;
using AspProjekat2024.Implementation.UseCases.Queries.Ef;
using AspProjekat2024.Implementation;
using System.IdentityModel.Tokens.Jwt;
using AspProjekat2024.Implementation.Validators;
using AspProjekat2024.Application;
using AspProjekat2024.API.Core;
using AspProjekat2024.Application.Mail;

namespace AspYt.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
            services.AddTransient<IGetModelsQuery, EfGetModelsQuery>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<IUpdateUseAccessCommand, EfUpdateUserAccessCommand>();
            services.AddTransient<UpdateUserAccessDtoValidator>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<CreateBrandDtoValidator>();
            services.AddTransient<CreateModelDtoValidator>();
            services.AddTransient<ICreateSpecificationCommand, EfCreateSpecificationCommand>();
            services.AddTransient<CreateSpecificationDtoValidator>();

            // Replace with your Gmail credentials and app password
            services.AddTransient<IEmailService>(provider =>
                new EmailService("smtp.gmail.com", 587, "marko.markovic.33.21@ict.edu.rs", "huvumdbwlqayjfzm"));
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
