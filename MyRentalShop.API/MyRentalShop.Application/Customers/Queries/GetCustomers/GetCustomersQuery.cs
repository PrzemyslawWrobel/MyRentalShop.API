using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<GetCustomersVm>
    {
        public int CustomerId { get; set; }
    }
}
