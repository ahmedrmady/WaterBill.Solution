using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Interfaces;
using WaterBill.SAL.Interfaces;

namespace WaterBill.SAL.Services
{
    public class Service<T> : IService<T> where T:class
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<T?> AddAsync(T entity)
        {
            _unitOfWork.Repositry<T>().AddAsync(entity);
            return await _unitOfWork.CompleteAsync()>0?entity:null;
        }

        public async Task<bool> Delete(T entity)
        {
            _unitOfWork.Repositry<T>().Delete(entity);
            return await _unitOfWork.CompleteAsync() > 0 ? true : false;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {

           return await _unitOfWork.Repositry<T>().GetAllAsync();
        }
        public Task<T?> GetAsync(string id)
        => _unitOfWork.Repositry<T>().GetAsync(id);

        public async Task<T?> UpdateAsync(T entity)
        {
            _unitOfWork.Repositry<T>().Update(entity);
            return await _unitOfWork.CompleteAsync()>0?entity:null;
        }
    }
}
