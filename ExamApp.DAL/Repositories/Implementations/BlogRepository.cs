using ExamApp.Core.Entities;
using ExamApp.DAL.Context;
using ExamApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Repositories.Implementations
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
