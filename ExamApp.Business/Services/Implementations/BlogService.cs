using ExamApp.Business.Services.Interfaces;
using ExamApp.Business.ViewModels.BlogVM;
using ExamApp.Core.Entities;
using ExamApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        public readonly IBlogRepository _repo;

        public BlogService(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<Blog> Create(CreateBlogVM blogvm , string path )
        {
            Blog blog = new Blog()
            {
                Title = blogvm.Title,
                Description = blogvm.Description,
                ImgUrl = path,
            };
            _repo.Create( blog );
            await _repo.SaveChanges();
            return blog;
        }

        public void Delete(int id)
        {
           // Blog blog = _repo.GetByIdAsync(id);
           _repo.Delete(id);
            _repo.SaveChanges();
           
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            if (id < 0) throw new Exception("Id should not be less than zero");
            if (id == null) throw new Exception("Id should not be less than zero");
            return  await _repo.GetByIdAsync(id);
        }

        public async Task<Blog> Update(UpdateBlogVM blogvm , string path)
        {
            if (blogvm.Id < 0) throw new Exception("Id should not be less than zero");
            Blog blog = await _repo.GetByIdAsync(blogvm.Id);
            if (blogvm.Id == null) throw new Exception("Id should not be less than zero");
            blog.Title = blogvm.Title;
            blog.Description = blogvm.Description;
            blog.ImgUrl= path;
            _repo.Update(blog);
            await _repo.SaveChanges();
            return blog;
        }
    }
}
