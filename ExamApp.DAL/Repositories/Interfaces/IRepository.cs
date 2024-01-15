using ExamApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Repositories.Interfaces
{
    public interface IRepository <T> where T : BaseEntity, new()
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync (int id);
        Task Create (T entity);
        Task Update (T entity);
        void Delete (int id);
        Task SaveChanges();
    }
}
