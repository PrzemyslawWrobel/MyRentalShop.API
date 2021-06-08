using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }

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

   
        public string ContactPersonFirstName  { get; set; }
        public string ContactSecondFirstName { get; set; }
        public string ContactLastNameFirstName { get; set; }

    }
}
