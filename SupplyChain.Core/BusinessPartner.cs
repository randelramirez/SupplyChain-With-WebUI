using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core
{
    public abstract class BusinessPartner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

    }
}
