using ExamApp.Core.Entities.Base;
using ExamApp.DAL.Context;
using ExamApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
           await _table.AddAsync(entity);
        }

        public void Delete(int id)
        {
            T entity = _table.Find(id);
            _table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _table.Update(entity);
        }
    }
}
