using FluentValidation;

namespace MasterData.Trends
{
    public class CreateTrendRequestValidator : AbstractValidator<CreateTrendRequest>
    {
        public CreateTrendRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Filed Name cannot be empty");

            RuleFor(p => p)
                .Must(c => (c.UnitId != null) != (c.EquipmentId != null))
               .WithMessage("Only of fields UnitId or EquipmentId can be assigned");
        }
    }
}
