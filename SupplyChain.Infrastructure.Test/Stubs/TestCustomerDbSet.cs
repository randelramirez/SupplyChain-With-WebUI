using SupplyChain.Core;
using SupplyChain.Infrastructure.Test.Doubles;
using System.Linq;

namespace SupplyChain.Infrastructure.Test.Stubs
{
    public class TestCustomerDbSet : TestDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(c => c.Id == id);
        }
    }
}
