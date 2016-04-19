using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Test.Stubs
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public void Save()
        {
            //null pattern implementation
        }
    }
}
