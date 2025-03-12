using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddASync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });  //anonim bir metod oluşturarak (Task.Run(()=>{})) silme fonksiyonumuzu vermemiz gerekiyor.
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // _context = instance of a database context, to manage database interactions.
            // _context.set<TEntity>() = provides access to database tables dynamically.
            IQueryable<TEntity> query = _context.Set<TEntity>(); // Entitymizi abone ediyoruz.
            if (predicate != null) {
                query = query.Where(predicate); // query'e predicate'i ekledik.
            }
            if (includeProperties.Any()) {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); // 5 tane gelirse foreach ile 5 defa dönüp hepsini query'e eklemiş olacağım.
                }
            }
            return await query.ToListAsync(); // bize gelen değerlere göre query'mizi oluşturup kullanıcıya bir liste olarak dönüyoruz. 
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>(); 
            if (predicate != null)
            {
                query = query.Where(predicate); 
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); 
                }
            }

            return await query.SingleOrDefaultAsync(); // tek nesneyi kullanıcıya dönmek için SingleOrDefaultAsync() metodunu kullanıyoruz. 
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => {_context.Set<TEntity>().Update(entity); }); // tekrar anonim metod oluşturuyoruz. 
        }
    }
}
