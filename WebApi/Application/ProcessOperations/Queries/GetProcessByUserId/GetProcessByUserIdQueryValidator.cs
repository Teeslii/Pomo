using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProcessOperations.Queries.GetProcessByUserId
{
    public class GetProcessByUserIdQueryValidator : AbstractValidator<GetProcessByUserIdQuery>
    {
        public GetProcessByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(0);
        }
    }
}