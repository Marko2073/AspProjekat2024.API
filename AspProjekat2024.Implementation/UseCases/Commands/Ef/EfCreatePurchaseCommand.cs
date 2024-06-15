﻿using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreatePurchaseCommand : EfUseCase, ICreatePurchaseCommand
    {
        private readonly CreatePurchaseDtoValidator _validator;
        public EfCreatePurchaseCommand(DatabaseContext context, CreatePurchaseDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name =>"Add Product To Cart";

        public string Description => "Add product to cart des";

        public void Execute(CreatePurchaseDto request)
        {
            // Validate the request
            _validator.ValidateAndThrow(request);

            var existingPurchase = Context.Purchases.Where(x => x.ModelVersionId == request.ModelVersionId && x.UserCartId == request.UserCartId).FirstOrDefault();
            if(existingPurchase != null)
            {
                existingPurchase.Quantity += request.Quantity;
                Context.SaveChanges();
                return;
            }
            else
            {
                _validator.ValidateAndThrow(request);
                // Add the new Purchase to the context
                Context.Purchases.Add(new Domain.Purchase
                {
                    Quantity = request.Quantity,
                    ModelVersionId = request.ModelVersionId,
                    UserCartId = request.UserCartId
                });


            }

            // Save changes to the database
            Context.SaveChanges();

            
        }

    }
}
