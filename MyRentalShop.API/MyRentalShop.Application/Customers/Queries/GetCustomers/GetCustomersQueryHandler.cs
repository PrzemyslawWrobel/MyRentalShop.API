using MediatR;
using Microsoft.EntityFrameworkCore;
using MyRentalShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersVm>
    {
        private readonly IMyRentalShopDbContext _context;
        public GetCustomersQueryHandler(IMyRentalShopDbContext myRentalShopDbContext)
        {
            _context = myRentalShopDbContext;
        }
        public async Task<GetCustomersVm> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            //TODO
            var customers = await _context.Customers.ToListAsync();// .FirstOrDefaultAsync(cancellationToken);
            customers.OrderBy(p => p.Name).ToList();
             throw new Exception();//customers;
            

            //return customerVm;
        }
    }
}
