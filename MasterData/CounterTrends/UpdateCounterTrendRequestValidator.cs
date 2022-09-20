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
                .WithMessage("Поле Name не может быть пустым");

            RuleFor(p => p.TrendId)
                .NotEqual(Guid.Empty)
                .WithMessage("Поле TrendId не может быть пустым");

            RuleFor(p => p.Type)
               .IsInEnum()
               .WithMessage("Type должен быть типа enum")
               .NotEmpty()
               .WithMessage("Type не может быть пустым");

            RuleFor(p => p.RecordMode)
               .IsInEnum()
               .WithMessage( "RecordMode должен быть типа enum")
               .NotEmpty()
               .WithMessage("RecordMode не может быть пустым");
        }
    }
}
