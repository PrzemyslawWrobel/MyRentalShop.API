using MyRentalShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        /// <summary>
        /// Imie klienta
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Drugie Imię klienta, nie jest wymagane
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Nazwisko klienta
        /// </summary>
        public string LastName { get; set; }


        public override string ToString()
        {
            return $"{ FirstName} { SecondName} { LastName}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return SecondName;
            yield return LastName;
        }
    }
}
