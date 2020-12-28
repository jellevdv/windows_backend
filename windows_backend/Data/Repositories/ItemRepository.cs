using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {

        private readonly Context _context;
        private readonly DbSet<Item> _items;

        public ItemRepository(Context context)
        {
            _context = context;
            _items = context.Items;
        }

        #region BasicMethods
        public async Task Add(Item item)
        {
            if (await _items.ContainsAsync(item))
            {
                throw new ArgumentException("Item is already in the database!");
            }
            await _items.AddAsync(item);
            await SaveChanges();
        }

        public async Task Delete(Item item)
        {
            if (await _items.ContainsAsync(item))
            {
                _items.Remove(item);
                await SaveChanges();
            }
            else
            {
                throw new ArgumentException("Item is already deleted!");
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region GetMethods
        public async Task<List<Item>> GetAll()
        {
            return await _items.OrderBy(i => i.Id).ToListAsync();
        }

        public async Task<Item> GetBy(int id)
        {
            return await _items.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Item>> GetByCategory(int categoryId)
        {
            return await _items.Where(i => i.Category.Id == categoryId).ToListAsync();
        }
        #endregion

    }
}
