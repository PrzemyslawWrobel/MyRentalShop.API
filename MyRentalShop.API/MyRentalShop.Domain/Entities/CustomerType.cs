using MyRentalShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    /// <summary>
    /// Klasa służy do określania jakiego typu jest użytkownik
    /// Dostawca, Odbiorca
    /// </summary>
    public class CustomerType : AuditableEntity
    {
        public CustomerType()
        {
            //inicjalizacja listy Customers

            Customers = new List<Customer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        #region Relacje
        public List<Customer> Customers { get; set; } //= new List<Customer>(); - inicjalizacja listy nowszy sposób 
        #endregion
    }
}
