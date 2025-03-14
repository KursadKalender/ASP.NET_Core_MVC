using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable // Tüm repositoryleri tek bir yerden yönetebilmemizi sağlıyor. İşlem yaparken tüm repositoryleri newlemek yerine sadece UnitOfWork newlenir.
    {
        // Transaction yapısına sahiptir = Veritabanına gönderdiğimiz verilerin doğrulanması ve yönetimi. 

        IArticleRepository Articles { get; } // unitofwork.Articles
        ICategoryRepository Categories { get; } //unitofwork.Categories
        ICommentRepository Comments { get; } //unitofwork.Comments
        IRoleRepository Roles { get; } //unitofwork.Roles
        IUserRepository Users { get; } //unitofwork.Users

        // _unitOfWork.Categories.AddAsync(category);
        // _unitOfWork.Users.AddAsync(user);
        // _unitOfWork.SaveAsync();

        Task<int> SaveAsync();
    }
}
