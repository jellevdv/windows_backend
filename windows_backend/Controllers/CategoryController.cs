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

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        /// <summary>
        /// Get all categories 
        /// </summary>
        /// <returns>array of categories</returns>
        [HttpGet]
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
        [HttpGet("Category")]
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
        [HttpPost]
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
        [HttpDelete]
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
    }
}