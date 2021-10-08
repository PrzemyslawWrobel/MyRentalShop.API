using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TResponse, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TResponse request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(f => f != null).ToList();

                if(failures.Count !=0)
                {
                    throw new Exception();
                }
            }

            return await next();
        }
    }
}
