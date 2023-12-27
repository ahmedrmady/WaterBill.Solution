using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterBill.BAL.Interfaces
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        public IGenericRepositry<Tentity> Repositry<Tentity>() where Tentity : class;

        public Task<int> CompleteAsync();
    }
}
