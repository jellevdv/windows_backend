using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface ICategoryService
    {

        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(Category category);
        Task DeleteCategory(Category category);

        Task<List<Item>> GetItems();
        Task<Item> GetItemById(int id);
        Task AddItem(Item item);
        Task DeleteItem(Item item);

        Task<List<ItemTask>> GetTasks();
        Task<ItemTask> GetTaskById(int id);
        Task AddTask(ItemTask task);
        Task DeleteTask(ItemTask task);

    }
}
