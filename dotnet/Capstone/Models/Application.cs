using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Application
    {
        public int ApplicationId { get; }

        public int RenterId { get; }

        public int LandlordId { get; }

        public int PropertyId { get; }

        public string Name { get; }

        public string Email { get; }

        public int Tenants { get; }

        public string MoveInDate { get; }

        public decimal Income { get; }
    }
}
