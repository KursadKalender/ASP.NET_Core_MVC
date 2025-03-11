using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    // tüm entityler tarafından ortak kullanılacak temel fonksiyonları burada tanımlayacağım.
    // fonksiyonların soyut, abstract hallerini tanımladık. 
    public interface IEntityRepository<T> where T:class, IEntity, new() // buraya bir tip vereceğim ve verdiğim bu tipe göre repository işlemini yapacak.
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); // lambda expressionlar predicate'dir. 
         // var makale = repository.GetAsync(m=>m.ID == 25, m=>m.User, m=>m.Comments) ---> 25 ID'li makale ile birlikte kullanıcıyı ve yorumları da getirdik.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate =null, params Expression<Func<T, object>>[] includeProperties); //nullable
        // örneğin tüm kategorileri getirmek istiyorsak repository.GetAllAsync(); desek yeterli.
        // ama c# kategorisine ait tüm makaleleri getirmek istersem filtreleme için ---> repository.GetAllAsync(m=>m.Category.Name =="C#", m=>m.Category); dememiz gerekir. 
        Task AddASync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); // kontrol için bir soru soracağından predicate koymamız gerekiyor.
                                                                  // JavaScript isimli kategori var mı? var result = _categoryRepository.AnyAsync(c=>c.Name =="JavaScript");
        Task<int> CountAsync(Expression<Func<T, bool>> predicate); // belli şeylerin sayısını görmek isteyebiliriz, o yüzden predicate ile neyi istediğimizi belirtmeliyiz. 

    }
}
