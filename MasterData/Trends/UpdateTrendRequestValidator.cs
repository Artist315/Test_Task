using FluentValidation;

namespace MasterData.Trends
{
    public class UpdateTrendRequestValidator : AbstractValidator<UpdateTrendRequest>
    {
        public UpdateTrendRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Поле Name не может быть пустым");

            RuleFor(p => p)
                .Must(c => (c.UnitId != null) != (c.EquipmentId != null))
               .WithMessage("Только одно из полей UnitId и EquipmentId может быть задано");
        }
    }
}
