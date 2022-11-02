using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MinuteSetOperations.Command.DeleteMinuteSet
{
    public class DeleteMinuteSetCommandValidator : AbstractValidator<DeleteMinuteSetCommand>
    {
        public DeleteMinuteSetCommandValidator()
        {
            RuleFor(command => command.Minute).GreaterThan(0);
        }
    }
}