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
        /// Jaki adres domowy, do korespondencji, zamieszkanaia, wykonywania działalności
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// Nazwa ulicy
        /// </summary>
        public string FullAddress { get; set; }
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
                .ForMember(d => d.ContactPersonName, map => map.MapFrom(src => src.CustomerContactPerson.PersonName.ToString()));
                //.ForMember(d => d.Address, map => map.MapFrom(src => src.Addresses.OrderByDescending(p => p.)))

        }
    }
}
