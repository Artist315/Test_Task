using FluentValidation;

namespace MasterData.Units
{
    public class CreateUnitRequestValidator: AbstractValidator<CreateUnitRequest>
    {
        public CreateUnitRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Поле Name не может быть пустым");
        }
    }
}
