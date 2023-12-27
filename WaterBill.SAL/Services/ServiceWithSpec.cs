using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL;
using WaterBill.BAL.Interfaces;
using WaterBill.BAL.Specifications;
using WaterBill.BAL.Specifications.SubscriptionSpecifications;
using WaterBill.DAL.Data.Entities;
using WaterBill.SAL.Interfaces;

namespace WaterBill.SAL.Services
{
    public class ServiceWithSpecs<T> : IServiceWithSpecs<T> where T:class
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceWithSpecs(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<T?> AddAsync(T entity)
        {
                _unitOfWork.Repositry<T>().AddAsync(entity);
            return await _unitOfWork.CompleteAsync() > 0 ? entity : null;
        }

        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
           

            return await _unitOfWork.Repositry<T>().CountAsync(spec);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecifications<T> spec)
        => await _unitOfWork.Repositry<T>().GetAllWithSpecAsync(spec);
        
        public  async Task<T?> GetAsync(string id)
           =>await _unitOfWork.Repositry<T>().GetAsync(id);

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> specPrams)
        => await _unitOfWork.Repositry<T>().GetWithSpecAsync(specPrams);

        public async Task<T?> UpdateAsync(T entity)
        {
            _unitOfWork.Repositry<T>().Update(entity);
            return await _unitOfWork.CompleteAsync() > 0 ? entity : null;
        }

    }
}
