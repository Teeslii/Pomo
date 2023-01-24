using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.UserOperations.Command.CreateToken
{
    public class CreateTokanCommandValidator: AbstractValidator<CreateTokenCommand>
    {
        public CreateTokanCommandValidator()
        {
            RuleFor(command => command.ViewModel.UserName).NotEmpty().MinimumLength(4);
           
            RuleFor(command => command.ViewModel.Password).NotEmpty().MinimumLength(6);
        }
    }
}