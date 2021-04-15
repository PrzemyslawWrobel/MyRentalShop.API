using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    public class Item
    {
        /// <summary>
        /// Id produktu autoinkrementacja na bazie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa produktu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// rozszerzona nazwa produktu
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Nr inwentarzowy np kod kreskowy, lub nr rejestracyjny pojazdu
        /// </summary>
        public int InventoryNumber { get; set; }

        /// <summary>
        /// Minimalny wiek wypożyczającego, sprzęt narzędzia
        /// </summary>
        public int MinAgeBorrower { get; set; }


        // Relacja do ItemType 1 ItemType może mieć w kolekcji wiele Itemów

        /// <summary>
        /// int? ItemTypeId - mówi o tym, że jest to property nie obowiązkowe
        /// </summar>
        public int? ItemTypeId { get; set; }
        /// <summary>
        /// Służy do stworzenia relacji
        /// </summary>
        public ItemType ItemType { get; set; }
    }
}
