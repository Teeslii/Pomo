using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MinuteSetOperations.Command.CreateMinuteSet
{
    public class CreateMinuteSetCommandValidator : AbstractValidator<CreateMinuteSetCommand>
    {
        public CreateMinuteSetCommandValidator()
        {
            RuleFor(command => command.viewModel.Minute).GreaterThanOrEqualTo(0);
        }
    }
}