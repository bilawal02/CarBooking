using CarBookingModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetSingleAsync(int id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task EditAsync(TEntity entity);
        Task<bool> ExistsAsync(int id);
        Task<int> SaveAsync();
    }
}
