using FluentValidation;

namespace MasterData.Units
{
    public class CreateUnitRequestValidator: AbstractValidator<CreateUnitRequest>
    {
        public CreateUnitRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Filed Name cannot be empty");
        }
    }
}
