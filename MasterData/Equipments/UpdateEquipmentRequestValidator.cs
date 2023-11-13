using System;
using FluentValidation;

namespace MasterData.Equipments
{
    public class UpdateEquipmentRequestValidator: AbstractValidator<UpdateEquipmentRequest>
    {
        public UpdateEquipmentRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Field Name cannot be empty");
            
            RuleFor(p => p.UnitId)
               .NotEqual(Guid.Empty)
               .WithMessage("Field UnitId cannot be empty");
        }
        
    }
}
