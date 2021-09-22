using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyRentalShop.Application.Common.Interfaces;
using MyRentalShop.Domain.Entities;
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
        private readonly IMapper _mapper;
        public GetCustomerDetailQueryHandler(IMyRentalShopDbContext myRentalShopDbContext, IMapper mapper)
        {
            _context = myRentalShopDbContext;
            _mapper = mapper;
        }

        public async Task<GetCustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(p => p.Id == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
            
            //Mapowanie przy użyciu automappera
            var customerVm = _mapper.Map<GetCustomerDetailVm>(customer);

            //Mapowanie bez użycia automappera

            //var customerVm = new GetCustomerDetailVm()
            //{
            //    FullName = customer.Name,
            //    ContactPerson = customer.CustomerContactPerson.ToString(),
            //    Address = customer.Addresses.OrderByDescending(p =>p.Country).FirstOrDefault().City
            //};

            return customerVm;
        }
    }
}
