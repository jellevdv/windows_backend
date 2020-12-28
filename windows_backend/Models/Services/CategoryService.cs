using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models.Interfaces;

namespace windows_backend.Models.Services
{
    public class CategoryService: ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ITaskRepository _taskRepository;

        public CategoryService(
            ICategoryRepository categoryRepository, 
            IItemRepository itemRepository, 
            ITaskRepository taskRepository)
        {
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _taskRepository = taskRepository;
        }

        #region Categories
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetBy(id);
        }
        public async Task AddCategory(Category category)
        {
            await _categoryRepository.Add(category);
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryRepository.Delete(category);
        }
        #endregion

        #region Items
        public async Task<List<Item>> GetItems()
        {
            return await _itemRepository.GetAll();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _itemRepository.GetBy(id);
        }

        public async Task AddItem(Item item)
        {
            await _itemRepository.Add(item);
        }

        public async Task DeleteItem(Item item)
        {
            await _itemRepository.Delete(item);
        }
        #endregion

        #region Tasks
        public async Task<List<ItemTask>> GetTasks()
        {
            return await _taskRepository.GetAll();
        }

        public async Task<ItemTask> GetTaskById(int id)
        {
            return await _taskRepository.GetBy(id);
        }

        public async Task AddTask(ItemTask task)
        {
            await _taskRepository.Add(task);
        }

        public async Task DeleteTask(ItemTask task)
        {
            await _taskRepository.Delete(task);
        }
        #endregion
    }
}
