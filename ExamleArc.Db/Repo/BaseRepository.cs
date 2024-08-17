
using ExampleArc.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamleArc.Db.Repo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private ExampleArcDbContext _context;
        private DbSet<T> _dbSet;
        public BaseRepository(ExampleArcDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<List<T>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public virtual async Task<T> Create(T p)
        {

            var itemNew = _dbSet.Add(p).Entity;
            await _context.SaveChangesAsync();

            _context.Entry(p).State = EntityState.Detached;
            //_context.SaveChanges();

            return itemNew;
        }
        public async Task<T> Update(T p)
        {
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _context.Entry(p).State = EntityState.Detached;
            return p;
        }
        public async Task Delete(T p)
        {
            _dbSet.Attach(p);
            _dbSet.Remove(p);
            await _context.SaveChangesAsync();
        }
        public T FindById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return null;
            }

            _context.Entry(entity).State = EntityState.Detached;
            _context.SaveChanges();

            return entity;
        }
    }
}
