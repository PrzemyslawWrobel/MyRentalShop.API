using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.Entities
{
    public class ContactDetailType
    {
        public ContactDetailType()
        {
            ContactDetails = new List<ContactDetail>();
        }
        public int Id { get; set; }

        /// <summary>
        /// Przechowuje informacje czy tel, faksu czy adres email są: prywatne, firmowe itp
        /// </summary>
        public string Name { get; set; }

        #region Relacje
        public List<ContactDetail> ContactDetails { get; set; }
        #endregion
    }
}
