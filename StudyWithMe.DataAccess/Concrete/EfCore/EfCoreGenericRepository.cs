using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context; 
        public EfCoreGenericRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}