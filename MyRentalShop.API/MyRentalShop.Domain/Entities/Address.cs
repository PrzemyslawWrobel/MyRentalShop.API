using MyRentalShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Jaki adres domowy, do korespondencji, zamieszkanaia, wykonywania działalności
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// Nazwa ulicy
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Numer Bloku, Domu
        /// </summary>
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        public string FlatNumber { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Nazwa miasta, Wsi
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Nazwa Kraju
        /// </summary>
        public string Country { get; set; }

        //Relacja 1 Customer może mieć wiele adresów. int? oznacza że adres nie jest wymagany
        public int? CustomerId { get; set; }
        //Relacja do Customera 
        public Customer Customer { get; set; }


    }
}
