using CleanArchitecture.Application.Interfaces;
using CleanArhitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhitecture.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepositoryAsync(ApplicationDbContext dbContext) => _dbContext = dbContext;

        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {           
            await Table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsnyc()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await Table.FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await Table.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
