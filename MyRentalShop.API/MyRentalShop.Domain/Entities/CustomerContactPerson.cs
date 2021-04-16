﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    public class CustomerContactPerson
    {
        public int Id { get; set; }

        /// <summary>
        /// Pozycja jaką zajmuje użytkownik w firmie
        /// </summary>
        public string Position { get; set; }

        //Relacje

        public int CustomerId { get; set; }
        /// <summary>
        /// Relacja 1:1 z Customerem jeden Customer ma jedną osobę do kontaktu
        /// </summary>
        public Customer Customer { get; set; }
    }
}
