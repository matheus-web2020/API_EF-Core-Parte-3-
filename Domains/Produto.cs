using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_API.Domains
{
    public class Produto : BaseDomains
    {

        public string Nome { get; set; }
        public float Preco { get; set; }



    }
}
