using FluentValidation;

namespace MasterData.Trends
{
    public class UpdateTrendRequestValidator : AbstractValidator<UpdateTrendRequest>
    {
        public UpdateTrendRequestValidator()
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
