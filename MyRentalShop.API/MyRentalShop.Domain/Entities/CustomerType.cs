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
    public class CustomerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
