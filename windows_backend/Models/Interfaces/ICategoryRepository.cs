using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetBy(int id);
        Task<List<Category>> GetByHoliday(int holidayId);
        Task<List<Category>> GetAll();
        Task Add(Category category);
        Task Delete(Category category);
        Task SaveChanges();
    }
}
