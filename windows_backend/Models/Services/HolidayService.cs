using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models.Interfaces;

namespace windows_backend.Models.Services
{
    public class HolidayService: IHolidayService
    {

        private readonly IHolidayRepository _holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task AddCategory(int id, Category category)
        {
            await _holidayRepository.AddCategory(id, category);
        }

        public async Task AddHoliday(Holiday holiday)
        {
            await _holidayRepository.Add(holiday);
        }

        public async Task DeleteHoliday(Holiday holiday)
        {
            await _holidayRepository.Delete(holiday);
        }

        public async Task<List<HolidayCategory>> GetCategories(int id)
        {
            return await _holidayRepository.GetCategories(id);
        }

        public async Task<Holiday> GetHolidayById(int id)
        {
            return await _holidayRepository.GetBy(id);
        }

        public async Task<List<Holiday>> GetHolidays()
        {
            return await _holidayRepository.GetAll();
        }
    }
}
