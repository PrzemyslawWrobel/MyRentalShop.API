using Microsoft.EntityFrameworkCore;
using Moq;
using MyRentalShop.Application.Common.Interfaces;
using MyRentalShop.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public static class MyRentalShopDbContextFactory
    {
        public static Mock<MyRentalShopDbContext> Create()
        {
            var dateTime = new DateTime(2000, 01, 1);
            var dataTimeMock = new Mock<IDateTime>();
            dataTimeMock.Setup(m => m.Now).Returns(dateTime);

            var curentUserMock = new Mock<ICurrentUserService>();
            curentUserMock.Setup(m => m.Email).Returns("user@user.pl");
            curentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<MyRentalShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<MyRentalShopDbContext>(options, dataTimeMock.Object, curentUserMock.Object) { CallBase = true };

            var context = mock.Object;

            context.Database.EnsureCreated();

            //TODO przykłądaowe dane

            return mock;
        }

        public static void Destroy(MyRentalShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

