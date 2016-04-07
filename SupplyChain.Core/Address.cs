using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core
{
    public class Address
    {
        public string Street { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        public string State { get; set; }

    }
}
