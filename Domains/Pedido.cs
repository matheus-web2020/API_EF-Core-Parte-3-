using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_API.Domains
{
    public class Pedido : BaseDomains
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }


    }
}
