using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryID);
        Task<IDataResult<IList<Category>>> GetAll(); // Data döneceği için IDataResult kullanıyoruz.
        Task<IDataResult<IList<Category>>> GetAllByNonDeleted();
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName); // Successs veya Error mesajı döneceğinden IResult kullanılacak. 
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryID, string modifiedByName); // Sadece IsDeleted değerini 1'e çeker.
        Task<IResult> HardDelete(int categoryID); // Tamamen, veritabanından siler. 
    }
}
