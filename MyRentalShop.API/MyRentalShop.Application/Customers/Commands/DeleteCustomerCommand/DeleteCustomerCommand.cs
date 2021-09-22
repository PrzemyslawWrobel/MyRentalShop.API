using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}
