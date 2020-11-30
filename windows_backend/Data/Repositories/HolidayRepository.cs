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
        }

        public async Task Delete(Holiday holiday)
        {
            if (await _holidays.ContainsAsync(holiday))
            {
                _holidays.Remove(holiday);
            }
            else
            {
                throw new ArgumentException("Holiday is already deleted!");
            }
        }

        public async Task<List<Holiday>> GetAll()
        {
            return await _holidays.OrderBy(h => h.id).ToListAsync();
        }

        public async Task<Holiday> GetBy(int id)
        {
            return await _holidays.SingleOrDefaultAsync(h => h.id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
