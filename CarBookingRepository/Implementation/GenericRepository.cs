using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void EditAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _dbSet.FindAsync(id);
            _dbSet.Remove(record);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
