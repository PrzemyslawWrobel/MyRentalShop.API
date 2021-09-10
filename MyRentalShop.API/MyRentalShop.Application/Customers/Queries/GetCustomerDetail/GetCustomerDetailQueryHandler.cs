using MediatR;
using Microsoft.EntityFrameworkCore;
using MyRentalShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, GetCustomerDetailVm>
    {
        private readonly IMyRentalShopDbContext _context;
        public GetCustomerDetailQueryHandler(IMyRentalShopDbContext myRentalShopDbContext)
        {
            _context = myRentalShopDbContext;
        }

        public async Task<GetCustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(p => p.Id == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
            var customerVm = new GetCustomerDetailVm()
            {
                FullName = customer.Name,
                ContactPerson = customer.CustomerContactPerson.ToString(),
                Address = customer.Addresses.OrderByDescending(p =>p.Country).FirstOrDefault().City
            };

            return customerVm;
        }
    }
}
