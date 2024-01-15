using ExamApp.Business.ViewModels.BlogVM;
using ExamApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> Create(CreateBlogVM blogvm, string path);
        Task<Blog> Update(UpdateBlogVM blogvm , string path);
        void Delete(int id);
    }
}
