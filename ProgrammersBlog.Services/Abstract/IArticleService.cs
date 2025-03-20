using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleID);
        Task<IDataResult<ArticleListDto>> GetAll(); // Data döneceği için IDataResult kullanıyoruz.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndCvtive(); // Hem silinmemiş hem aktif, tamamlanmış ve sorunsuz makaleleri göstermek için. 
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryID);
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName); // Successs veya Error mesajı döneceğinden IResult kullanılacak. 
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleID, string modifiedByName); // Sadece IsDeleted değerini 1'e çeker.
        Task<IResult> HardDelete(int articleID); // Tamamen, veritabanından siler. 
    }
}
