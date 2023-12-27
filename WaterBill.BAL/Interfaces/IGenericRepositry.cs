using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Specifications;

namespace WaterBill.BAL.Interfaces
{
    public interface IGenericRepositry<T>where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);

        Task<T?> GetAsync(string id);

        Task<T?> GetWithSpecAsync(ISpecifications<T> spec);


        Task<int> CountAsync(ISpecifications<T> spec);


        void AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
