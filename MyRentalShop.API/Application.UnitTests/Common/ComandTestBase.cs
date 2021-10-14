using Moq;
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
        protected readonly MyRentalShopDbContext _context;
        protected readonly Mock<MyRentalShopDbContext> _contextMock;

        public ComandTestBase()
        {
            _contextMock = MyRentalShopDbContextFactory.Create();
            _context = _contextMock.Object;
        }
        public void Dispose()
        {
            MyRentalShopDbContextFactory.Destroy(_context);
        }
    }
}
