using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Data.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly Context _context;
        private readonly DbSet<Holiday> _holidays;

        public HolidayRepository(Context context)
        {
            _context = context;
            _holidays = context.Holidays;
        }

        public async Task Add(Holiday holiday)
        {
            if (await _holidays.ContainsAsync(holiday))
            {
                throw new ArgumentException("Holiday is already in the database!");
            }
            await _holidays.AddAsync(holiday);
            await SaveChanges();
        }

        public async Task AddCategory(int id, Category category)
        {
            Holiday holiday = await _holidays.SingleOrDefaultAsync(h => h.Id == id);
            holiday.AddCategory(category);
            await SaveChanges();
        }

        public async Task Delete(Holiday holiday)
        {
            if (await _holidays.ContainsAsync(holiday))
            {
                _holidays.Remove(holiday);
                await SaveChanges();
            }
            else
            {
                throw new ArgumentException("Holiday is already deleted!");
            }
        }

        public async Task<List<Holiday>> GetAll()
        {
            return await _holidays.OrderBy(h => h.Id).ToListAsync();
        }

        public async Task<Holiday> GetBy(int id)
        {
            return await _holidays.SingleOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<HolidayCategory>> GetCategories(int id)
        {
            //todo error meldingen
            Holiday holiday = await GetBy(id);
            return holiday.Categories.ToList();
        }

        public async Task<List<Item>> GetItems(int id)
        {
            //todo meldingen
            List<Item> items = new List<Item>();
            Holiday holiday = await _holidays.SingleOrDefaultAsync(h => h.Id == id);
            holiday.Categories.ForEach(c => c.Category.Items.ForEach(d => items.Add(d)));
            return items;
        }

        public async Task<List<ItemTask>> GetTasks(int id)
        {
            //todo meldingen
            /*
            List<Item> items = new List<Item>();
            List<ItemTask> tasks = new List<ItemTask>();
            Holiday holiday = await _holidays.SingleOrDefaultAsync(h => h.Id == id);
            holiday.Categories.ForEach(c => c.Items.ForEach(d => items.Add(d)));
            items.ForEach(t => tasks.Add(t.t));
            */
            return null;
        }



        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
