﻿using FluentValidation;

namespace MasterData.Units
{
    public class UpdateUnitRequestValidator: AbstractValidator<UpdateUnitRequest>
    {
        public UpdateUnitRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Filed Name cannot be empty");
        }
        
    }
}
