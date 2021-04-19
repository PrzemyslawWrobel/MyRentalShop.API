using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    /// <summary>
    /// Klasa dodająca tagi po których możemy wyszukiwać produkty
    /// Jeden produkt może mieć wiele tagów
    /// </summary>
    public class ItemTag
    {

        public ItemTag()
        {
            //inicjalizacja listy Items
            Items = new List<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        #region Relacje
        public List<Item> Items { get; set; }
        #endregion
    }
}
