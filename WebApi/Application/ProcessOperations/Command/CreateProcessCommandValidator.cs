using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProcessOperations.Command
{
    public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
    {
        public CreateProcessCommandValidator()
        {
           
            RuleFor(command => command.Model.MinuteSetId ).GreaterThan(0);
            RuleFor(command => command.Model.IsCompleted).NotNull();
            RuleFor(command => command.Model.UserId).GreaterThan(0);
        }
    }
}