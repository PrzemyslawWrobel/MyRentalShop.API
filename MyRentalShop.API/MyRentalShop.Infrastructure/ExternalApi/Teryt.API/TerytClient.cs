using MyRentalShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentalShop.Infrastructure.ExternalApi.Teryt.API
{
    public class TerytClient : ITerytClient
    {
        public Task<string> GetAdress(string searchFilter, CancellationToken cancellationToken)
        {
            //TODO Zaimplementować metodę do pobierania adresów

            //
            // dane do logowania po rejestracji do systemu teryt

            throw new NotImplementedException();
        }
    }
}
