using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;

        }
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requstName = typeof(TRequest).Name;

            _logger.LogInformation("MyRentalShop Request: {Name} {@Request}", requstName, request);
        }
    }
}
