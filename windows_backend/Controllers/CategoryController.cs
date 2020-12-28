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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ITaskRepository _taskRepository;

        public CategoryController(ICategoryRepository categoryRepository, IItemRepository itemRepository, ITaskRepository taskRepository)
        {
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _taskRepository = taskRepository;
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
            try
            {
                return await _categoryRepository.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Categories not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetCategoryById
        /// <summary>
        /// Get category by id 
        /// </summary>
        /// <returns>category</returns>
        [HttpGet("CategoryById")]
        public async Task<Category> GetCategoryById(int catId)
        {
            try
            {
                return await _categoryRepository.GetBy(catId);
            }
            catch (Exception e)
            {
                BadRequest("Category not found! " + e.Message);
                return null;
            }
        }


        //POST: api/AddCategory
        /// <summary>
        /// Add category
        /// </summary>
        [HttpPost("Category")]
        public async Task AddCategory(Category category)
        {
            try
            {
                await _categoryRepository.Add(category);
            }
            catch (Exception e)
            {
                BadRequest("Category not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteCategory
        /// <summary>
        /// Delete category 
        /// </summary>
        [HttpDelete("Category")]
        public async Task DeleteCategory(Category category)
        {
            try
            {
                await _categoryRepository.Delete(category);
            }
            catch (Exception e)
            {
                BadRequest("Category not deleted! " + e.Message);
            }
        }
        #endregion

        #region items
        // GET: api/Items
        /// <summary>
        /// Get all items 
        /// </summary>
        /// <returns>array of items</returns>
        [HttpGet("Items")]
        public async Task<IEnumerable<Item>> GetItems()
        {
            try
            {
                return await _itemRepository.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Items not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetItemById
        /// <summary>
        /// Get Item by id 
        /// </summary>
        /// <returns>Item</returns>
        [HttpGet("Item")]
        public async Task<Item> GetItemById(int itemId)
        {
            try
            {
                return await _itemRepository.GetBy(itemId);
            }
            catch (Exception e)
            {
                BadRequest("Item not found! " + e.Message);
                return null;
            }
        }

        //POST: api/AddItem
        /// <summary>
        /// Add Item
        /// </summary>
        [HttpPost("Item")]
        public async Task AddItem(Item Item)
        {
            try
            {
                await _itemRepository.Add(Item);
            }
            catch (Exception e)
            {
                BadRequest("Item not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteItem
        /// <summary>
        /// Delete Item 
        /// </summary>
        [HttpDelete("Item")]
        public async Task DeleteItem(Item Item)
        {
            try
            {
                await _itemRepository.Delete(Item);
            }
            catch (Exception e)
            {
                BadRequest("Item not deleted! " + e.Message);
            }
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
            try
            {
                return await _taskRepository.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Tasks not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetTaskById
        /// <summary>
        /// Get Task by id 
        /// </summary>
        /// <returns>Task</returns>
        [HttpGet("TaskById")]
        public async Task<ItemTask> GetTaskById(int TaskId)
        {
            try
            {
                return await _taskRepository.GetBy(TaskId);
            }
            catch (Exception e)
            {
                BadRequest("Task not found! " + e.Message);
                return null;
            }
        }

        //POST: api/AddTask
        /// <summary>
        /// Add Task
        /// </summary>
        [HttpPost("Task")]
        public async Task AddTask(ItemTask itemTask)
        {
            try
            {
                await _taskRepository.Add(itemTask);
            }
            catch (Exception e)
            {
                BadRequest("Task not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteTask
        /// <summary>
        /// Delete Task 
        /// </summary>
        [HttpDelete("Task")]
        public async Task DeleteTask(ItemTask itemTask)
        {
            try
            {
                await _taskRepository.Delete(itemTask);
            }
            catch (Exception e)
            {
                BadRequest("Task not deleted! " + e.Message);
            }
        }
        #endregion
    }
}