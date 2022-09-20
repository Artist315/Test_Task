using FluentValidation;

namespace MasterData.Trends
{
    public class CreateTrendRequestValidator : AbstractValidator<CreateTrendRequest>
    {
        public CreateTrendRequestValidator()
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
