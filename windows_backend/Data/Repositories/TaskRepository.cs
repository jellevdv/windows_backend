using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly Context _context;
        private readonly DbSet<ItemTask> _tasks;

        public TaskRepository(Context context)
        {
            _context = context;
            _tasks = context.Tasks;
        }

        #region BasicMethods
        public async Task Add(ItemTask task)
        {
            if (await _tasks.ContainsAsync(task))
            {
                throw new ArgumentException("Task is already in the database!");
            }
            await _tasks.AddAsync(task);
            await SaveChanges();
        }

        public async Task Delete(ItemTask task)
        {
            if (await _tasks.ContainsAsync(task))
            {
                _tasks.Remove(task);
                await SaveChanges();
            }
            else
            {
                throw new ArgumentException("Task is already deleted!");
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region GetMethods
        public async Task<List<ItemTask>> GetAll()
        {
            return await _tasks.OrderBy(t => t.Id).ToListAsync();
        }

        public async Task<ItemTask> GetBy(int id)
        {
            return await _tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<ItemTask>> GetByItem(int itemId)
        {
            return await _tasks.Where(t => t.Item.Id == itemId).ToListAsync();
        }
        #endregion
    }
}
