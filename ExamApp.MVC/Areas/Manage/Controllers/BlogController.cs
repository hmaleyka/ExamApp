using ExamApp.Business.Helpers;
using ExamApp.Business.Services.Interfaces;
using ExamApp.Business.ViewModels.BlogVM;
using ExamApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _service;
        private readonly IWebHostEnvironment _env;
        public BlogController(IBlogService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _service.GetAllAsync();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogVM blogvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string path = blogvm.Image.Upload(_env.WebRootPath, @"\Upload\Product\");

            await _service.Create(blogvm, path);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _service.GetByIdAsync(id);

            UpdateBlogVM updateBlogVM = new UpdateBlogVM()
            {
                Title = blog.Title,
                Description = blog.Description,
                ImageUrl = blog.ImgUrl
            };
            return View(updateBlogVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogVM blogvm)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}
            string path = blogvm.Image.Upload(_env.WebRootPath, @"\Upload\Product\");
            await _service.Update(blogvm, path);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {    
             _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
