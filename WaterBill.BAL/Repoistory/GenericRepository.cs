using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Interfaces;
using WaterBill.BAL.Specifications;
using WaterBill.BAL.SpecificationsEvaluator;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.BAL.Repoistories
{
    public class GenericRepository<T> : IGenericRepositry<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext appDbContext)
        => this._context = appDbContext;
        
        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        => _context.Set<T>().Remove(entity);



        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync() ;

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifications(spec).ToListAsync();
        }


        public async Task<T?> GetAsync(string id)
         => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
        
        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifications(spec).CountAsync();
        }

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifications(spec).FirstOrDefaultAsync() as T;
        }



       

        private IQueryable<T> ApplaySpecifications(ISpecifications<T> spec)
        {
            return SpecifcationsEvalutor<T>.GetQuery(_context.Set<T>(), spec);
        }

       
    }
}
