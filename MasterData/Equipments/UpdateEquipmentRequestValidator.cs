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
               .WithMessage("Поле Name не может быть пустым");
            
            RuleFor(p => p.UnitId)
               .NotEqual(Guid.Empty)
               .WithMessage("Поле UnitId не может быть пустым");
        }
        
    }
}
