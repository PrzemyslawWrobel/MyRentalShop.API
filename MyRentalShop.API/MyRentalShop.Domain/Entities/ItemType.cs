using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    /// <summary>
    /// Klasa służy do określania jakiego typu jest produkt
    /// </summary>
    public class ItemType
    {
        public ItemType()
        {
            //inicjalizacja listy Items
            Items = new List<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Służy do stworzenia relacji 1 ItemType do wielu Itemów 
        public List<Item> Items { get; set; }
    }
}
