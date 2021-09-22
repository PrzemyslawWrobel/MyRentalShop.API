using MediatR;
using Microsoft.EntityFrameworkCore;
using MyRentalShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IMyRentalShopDbContext _context;

        public DeleteCustomerCommandHandler(IMyRentalShopDbContext myRentalShopDbContext)
        {
            _context = myRentalShopDbContext;
        }
     
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(p => p.Id == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
