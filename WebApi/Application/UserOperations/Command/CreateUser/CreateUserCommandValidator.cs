using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.UserOperations.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
              RuleFor(command => command.viewModel.UserName).NotEmpty().MinimumLength(4);
           
              RuleFor(command => command.viewModel.Password).NotEmpty().MinimumLength(6);
        }
    }
}