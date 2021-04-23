using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalShop.Application.Interfaces
{
    public interface IDataTime
    {
        public DateTime Now { get; }
    }
}
