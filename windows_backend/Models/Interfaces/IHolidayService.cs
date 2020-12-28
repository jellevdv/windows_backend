using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface IHolidayService
    {

        Task<List<Holiday>> GetHolidays();
        Task<Holiday> GetHolidayById(int id);
        Task<List<HolidayCategory>> GetCategories(int id);
        Task AddHoliday(Holiday holiday);
        Task AddCategory(int id, Category category);
        Task DeleteHoliday(Holiday holiday);

    }
}
