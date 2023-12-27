using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Interfaces;
using WaterBill.BAL.Repoistories;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private Hashtable Repositoris;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Repositoris = new Hashtable();
        }

        public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

        public IGenericRepositry<Tentity> Repositry<Tentity>() where Tentity : class
        {
            var key = typeof(Tentity).Name;
            if (!Repositoris.ContainsKey(key))
            {
                Repositoris.Add(key, new GenericRepository<Tentity>(_context));
            }

            return Repositoris[key] as IGenericRepositry<Tentity>;

        }
    }
}
