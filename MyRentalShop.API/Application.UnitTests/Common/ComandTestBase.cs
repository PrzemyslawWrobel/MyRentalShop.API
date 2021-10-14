using MyRentalShop.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class ComandTestBase : IDisposable // Po teście bedzie niszczony obiekt bazy danych
    {
        protected readonly MyRentalShopDbContext
        public ComandTestBase()
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
