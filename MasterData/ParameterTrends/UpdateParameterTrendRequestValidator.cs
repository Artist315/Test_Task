using FluentValidation;
using System;
namespace MasterData.ParameterTrends
{
    public class UpdateParameterTrendRequestValidator : AbstractValidator<UpdateParameterTrendRequest>
    {
        public UpdateParameterTrendRequestValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Field Name cannot be empty");

            RuleFor(p => p.TrendId)
               .NotEqual(Guid.Empty)
               .WithMessage("Field TrendId cannot be empty");

            RuleFor(p => p.RecordMode)
               .IsInEnum()
               .WithMessage("RecordMode must be enum")
               .NotEmpty()
               .WithMessage("RecordMode cannot be empty");
        }
    }
}
