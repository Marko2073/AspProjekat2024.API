﻿using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class UpdateSpecificationDtoValidator : AbstractValidator<UpdateSpecificationDto>
    {
        private readonly DatabaseContext _context;

        public UpdateSpecificationDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Specification name is required")
                .MinimumLength(2).WithMessage("Specification name must have at least 3 characters");

            RuleFor(x => x.ParentId)
                .Must(x => x == null || context.Specifications.Any(s => s.Id == x))
                .WithMessage("Parent specification with provided id doesn't exist or is invalid.");
        }
    }
}
