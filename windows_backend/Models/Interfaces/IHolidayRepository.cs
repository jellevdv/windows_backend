using System.Collections.Generic;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface IHolidayRepository
    {
        Task<Holiday> GetBy(int id);
        Task<List<Holiday>> GetAll();
        Task<List<Category>> GetCategories(int id);
        Task<List<Item>> GetItems(int id);
        Task<List<ItemTask>> GetTasks(int id);
        Task Add(Holiday holiday);
        Task AddCategory(int id, Category category);
        Task Delete(Holiday holiday);
        Task SaveChanges();
    }
}
