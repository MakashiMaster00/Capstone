using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int RenterId { get; set; }

        public int LandlordId { get; set; }

        public int PropertyId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Tenants { get; set; }

        public string MoveInDate { get; set; }

        public decimal Income { get; set; }

        public string Status { get; set; }
    }
}
