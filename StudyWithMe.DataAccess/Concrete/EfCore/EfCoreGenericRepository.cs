using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    // TEntity'de class yerine soyut class verilmemesi için referans tipinin newlenebilir class olması gerektiğini belirtmek için kullanılır.
    // new() constraint'i her zaman en sona yazılır.
    // atanan class IEntity ile imzalanmış olmalıdır.
    // TEntity gibi TContext'de eklenmelidir.
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        /// <summary>
        /// regionlar classın içerisindeki metodlarımızı bölgelere ayırmak için kullanılır.
        /// </summary>
        #region fields
        protected readonly DbContext _context;
        #endregion

        #region ctor
        public EfCoreGenericRepository(DbContext context)
        {
            _context = context;
        }
        #endregion

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        // List yerine IQuerable döndürmek daha mantıklı !!! Araştır !!!
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