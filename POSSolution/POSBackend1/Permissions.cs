using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class Permissions
    {
        public bool CanViewInventory{ get; set; }
        public bool CanUpdateInventory { get; set; }
        public bool IsSuperUser { get; set; }
    }
}
