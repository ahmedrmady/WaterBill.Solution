using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Specifications;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.SAL.Interfaces
{
    public interface IServiceWithSpecs<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecifications<T> specPrams );

        Task<T?> AddAsync(T entity);

         Task<T?> GetAsync(string id);

         Task<T?> GetWithSpecAsync(ISpecifications<T> specPrams);
   

        Task<T?> UpdateAsync(T entity);

        Task<int> CountAsync(ISpecifications<T> specPrams);
    }
}
