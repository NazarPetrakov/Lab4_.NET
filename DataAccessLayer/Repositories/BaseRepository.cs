﻿using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SocialNetworkDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SocialNetworkDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsync();
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await SaveAsync();
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
             return await SaveAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> IsExistAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity is not null;
        }
        public async Task<bool> SaveAsync()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
