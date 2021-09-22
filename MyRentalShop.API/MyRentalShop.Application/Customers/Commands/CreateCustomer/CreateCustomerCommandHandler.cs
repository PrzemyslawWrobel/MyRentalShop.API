using MediatR;
using MyRentalShop.Application.Common.Interfaces;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IMyRentalShopDbContext _context;
        public CreateCustomerCommandHandler(IMyRentalShopDbContext myRentalShopDbContext)
        {
            _context = myRentalShopDbContext;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new()
            {
                Name = request.Name,
                REGON = request.REGON,
                NIP = request.NIP,



                //Addresses = new List<Address>
                //{
                //    Address = new Address()
                //    {
                //        Country = request.,
                //        City = request.,
                //        ZipCode = request.,
                //        Street = request.,
                //        BuildingNumber = request.,
                //        FlatNumber = request.,

                //    }
                //},

                
                
               
            };

            _context.Customers.Add(customer);

            ContactPerson contactPerson = new()
            {
                PersonName = new Domain.ValueObjects.PersonName
                {
                    FirstName = request.ContactPersonFirstName,
                    SecondName = request.ContactSecondFirstName,
                    LastName = request.ContactLastNameFirstName,

                },
                Position = request.Position,
                CustomerId = customer.Id,
            };
            _context.ContactPersons.Add(contactPerson);

            Address address = new()
            {
                //Country = request.,
                //        City = request.,
                //        ZipCode = request.,
                //        Street = request.,
                //        BuildingNumber = request.,
                //        FlatNumber = request.,

            };
            _context.Addresses.Add(address);

            
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
