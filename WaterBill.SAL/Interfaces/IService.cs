using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterBill.SAL.Interfaces
{
    public interface IService<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> GetAsync(string id);

        Task<T?> AddAsync(T entity);

        Task<T?> UpdateAsync(T entity);

        Task<bool> Delete(T entity);
    }
}
