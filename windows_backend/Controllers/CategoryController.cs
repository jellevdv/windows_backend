using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        #region Categories
        // GET: api/Categories
        /// <summary>
        /// Get all categories 
        /// </summary>
        /// <returns>array of categories</returns>
        [HttpGet("Categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryService.GetCategories();
        }

        //GET: api/GetCategoryById
        /// <summary>
        /// Get category by id 
        /// </summary>
        /// <returns>category</returns>
        [HttpGet("CategoryById")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryById(id);
        }


        //POST: api/AddCategory
        /// <summary>
        /// Add category
        /// </summary>
        [HttpPost("Category")]
        public async Task AddCategory(Category category)
        {
            await _categoryService.AddCategory(category);
        }


        //DELETE: api/DeleteCategory
        /// <summary>
        /// Delete category 
        /// </summary>
        [HttpDelete("Category")]
        public async Task DeleteCategory(Category category)
        {
            await _categoryService.DeleteCategory(category);
        }
        #endregion

        #region Items
        // GET: api/Items
        /// <summary>
        /// Get all items 
        /// </summary>
        /// <returns>array of items</returns>
        [HttpGet("Items")]
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _categoryService.GetItems();
        }

        //GET: api/GetItemById
        /// <summary>
        /// Get Item by id 
        /// </summary>
        /// <returns>Item</returns>
        [HttpGet("Item")]
        public async Task<Item> GetItemById(int id)
        {
            return await _categoryService.GetItemById(id);
        }

        //POST: api/AddItem
        /// <summary>
        /// Add Item
        /// </summary>
        [HttpPost("Item")]
        public async Task AddItem(Item item)
        {
            await _categoryService.AddItem(item);
        }


        //DELETE: api/DeleteItem
        /// <summary>
        /// Delete Item 
        /// </summary>
        [HttpDelete("Item")]
        public async Task DeleteItem(Item item)
        {
            await _categoryService.DeleteItem(item);
        }
        #endregion

        #region tasks
        // GET: api/Tasks
        /// <summary>
        /// Get all Tasks 
        /// </summary>
        /// <returns>array of Tasks</returns>
        [HttpGet("Tasks")]
        public async Task<IEnumerable<ItemTask>> GetTasks()
        {
            return await _categoryService.GetTasks();
        }

        //GET: api/GetTaskById
        /// <summary>
        /// Get Task by id 
        /// </summary>
        /// <returns>Task</returns>
        [HttpGet("TaskById")]
        public async Task<ItemTask> GetTaskById(int id)
        {
            return await _categoryService.GetTaskById(id);
        }

        //POST: api/AddTask
        /// <summary>
        /// Add Task
        /// </summary>
        [HttpPost("Task")]
        public async Task AddTask(ItemTask task)
        {
            await _categoryService.AddTask(task);
        }


        //DELETE: api/DeleteTask
        /// <summary>
        /// Delete Task 
        /// </summary>
        [HttpDelete("Task")]
        public async Task DeleteTask(ItemTask task)
        {
            await _categoryService.DeleteTask(task);
        }
        #endregion
    }
}