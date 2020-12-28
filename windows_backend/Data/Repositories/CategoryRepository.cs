using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        private readonly DbSet<Category> _categories;

        public CategoryRepository(Context context)
        {
            _context = context;
            _categories = context.Categories;
        }

        public async Task Add(Category category)
        {
            if (await _categories.ContainsAsync(category))
            {
                throw new ArgumentException("Category is already in the database!");
            }
            await _categories.AddAsync(category);
            await SaveChanges();
        }


        public async Task Delete(Category category)
        {
            if (await _categories.ContainsAsync(category))
            {
                _categories.Remove(category);
                await SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category is already deleted!");
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categories.OrderBy(t => t.Id).ToListAsync();
        }

        public async Task<Category> GetBy(int id)
        {
            return await _categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
