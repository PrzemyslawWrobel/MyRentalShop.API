using AutoMapper;
using MyRentalShop.Application.Common.Mappings;
using MyRentalShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailVm : IMapFrom<Customer>
    {
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Data rejestracji użytkownika
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Wiek klienta indywidualnego, wymagany do wyporzyczenia niektórych aut
        /// </summary>
        public int AgeCustomer { get; set; }

        /// <summary>
        /// Status informujący czy użytkownik może wypożyczać produkty
        /// </summary>
        public int CustomerStatusId { get; set; }

        /// <summary>
        /// NIP firmy wypożyczającej
        /// </summary>
        public string NIP { get; set; }

        /// <summary>
        /// Regon firmy wypożyczającej
        /// </summary>
        public string REGON { get; set; }

        /// <summary>
        /// Czy klient jest aktywny
        /// </summary>
        public bool IsActiv { get; set; }

        /// <summary>
        /// Pełna nazwa użytkownika
        /// </summary>
        public string ContactPersonName { get; set; }

        /// <summary>
        /// Pozycja jaką zajmuje osoba do kontaktów w firmie
        /// </summary>
        public string Position { get; set; }


        #region Adress

        /// <summary>
        /// Nazwa ulicy
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// Jaki adres domowy, do korespondencji, zamieszkanaia, wykonywania działalności
        /// </summary>
        public string AddressType { get; set; }

        #endregion

        #region Contact detail Information

        /// <summary>
        /// Przechowuje telefony, emil
        /// </summary>
        public string ContactDetailInformation { get; set; }

        #endregion

        #region Contact detail type
        /// <summary>
        /// Przechowuje informacje czy tel, faksu czy adres email są: prywatne, firmowe itp
        /// </summary>
        public string ContactDetailTypeName { get; set; }

        #endregion

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, GetCustomerDetailVm>()
                .ForMember(d => d.CustomerName, map => map.MapFrom(src => src.Name))
                .ForMember(d => d.RegistrationDate, map => map.MapFrom(src => src.RegistrationDate))
                .ForMember(d => d.AgeCustomer, map => map.MapFrom(src => src.AgeCustomer))
                .ForMember(d => d.CustomerStatusId, map => map.MapFrom(src => src.CustomerStatusId))
                .ForMember(d => d.NIP, map => map.MapFrom(src => src.NIP))
                .ForMember(d => d.REGON, map => map.MapFrom(src => src.REGON))
                .ForMember(d => d.IsActiv, map => map.MapFrom(src => src.IsActiv))
                .ForMember(d => d.ContactPersonName, map => map.MapFrom(src => src.CustomerContactPerson.PersonName.ToString()))
                .ForMember(d => d.Position, map => map.MapFrom(src => src.CustomerContactPerson.Position))
                .ForMember(d => d.FullAddress, map => map.MapFrom(src => src.Addresses.OrderByDescending(p => p.City)))
                .ForMember(d => d.AddressType, map => map.MapFrom(src => src.Addresses.OrderByDescending(p => p.AddressType)))
                .ForMember(d => d.ContactDetailTypeName, map => map.MapFrom(src => src.ContactDetails.OrderByDescending(p => p.ContactDetailInformation)))
                .ForMember(d => d.FullAddress, map => map.MapFrom(src => src.Addresses.OrderByDescending(p => p.City)));

        }
    }
}
