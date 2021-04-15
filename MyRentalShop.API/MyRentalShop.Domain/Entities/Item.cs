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
        /// jakiego typu jest produkt
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Minimalny wiek wypożyczającego, sprzęt narzędzia
        /// </summary>
        public int MinAgeBorrower { get; set; }

    }
}
