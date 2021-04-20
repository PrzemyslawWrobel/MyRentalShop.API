using MyRentalShop.Domain.Common;
using MyRentalShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    public class ContactPerson : AuditableEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Pozycja jaką zajmuje użytkownik w firmie
        /// </summary>
        public string Position { get; set; }
        
        /// <summary>
        /// Dane osoby do kontaktów
        /// </summary>
        public PersonName PersonName { get; set; }

        //Relacje

        public int CustomerId { get; set; }
        /// <summary>
        /// Relacja 1:1 z Customerem jeden Customer ma jedną osobę do kontaktu
        /// </summary>
        public Customer Customer { get; set; }
    }
}
