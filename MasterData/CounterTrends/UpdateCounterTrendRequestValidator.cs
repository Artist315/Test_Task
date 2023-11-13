using FluentValidation;
using System;

namespace MasterData.CounterTrends
{
    public class UpdateCounterTrendRequestValidator : AbstractValidator<UpdateCounterTrendRequest>
    {
        public UpdateCounterTrendRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Field Name cannot be empty");

            RuleFor(p => p.TrendId)
                .NotEqual(Guid.Empty)
                .WithMessage("Field TrendId cannot be empty");

            RuleFor(p => p.Type)
               .IsInEnum()
               .WithMessage("Type must be enum")
               .NotEmpty()
               .WithMessage("Type нcannot be empty");

            RuleFor(p => p.RecordMode)
               .IsInEnum()
               .WithMessage("RecordModemust be enum")
               .NotEmpty()
               .WithMessage("RecordMode cannot be empty");
        }
    }
}
