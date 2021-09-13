using AutoMapper;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailVm
    {
        public string FullName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, GetCustomerDetailVm>()
                .ForMember(d => d.FullName, map => map.MapFrom(src => src.Name))
                .ForMember(d => d.ContactPerson, map => map.MapFrom(src => src.CustomerContactPerson.PersonName.ToString()));
                //.ForMember(d => d.Address, map => map.MapFrom(src => src.Addresses.OrderByDescending(p => p.)))

        }
    }
}
