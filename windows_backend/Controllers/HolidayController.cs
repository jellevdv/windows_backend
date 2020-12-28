using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using windows_backend.Models;
using windows_backend.Models.Interfaces;

namespace windows_backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        // GET: api/Holidays
        /// <summary>
        /// Get all holidays 
        /// </summary>
        /// <returns>array of holidays</returns>
        [HttpGet]
        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            return await _holidayService.GetHolidays();
        }

        //GET: api/GetHolidayById
        /// <summary>
        /// Get holiday by id 
        /// </summary>
        /// <returns>holiday</returns>
        [HttpGet("Holiday")]
        public async Task<Holiday> GetHolidayById(int holidayId)
        {
            return await _holidayService.GetHolidayById(holidayId);
        }

        //GET: api/GetCategoriesOfHoliday
        /// <summary>
        /// Get categories of a certain holiday 
        /// </summary>
        /// <returns>array of categories</returns>
        [HttpGet("Categories")]
        public async Task<List<HolidayCategory>> GetCategories(int id)
        {
            return await _holidayService.GetCategories(id);
        }

        //POST: api/AddHoliday
        /// <summary>
        /// Add holiday
        /// </summary>
        [HttpPost("Holiday")]
        public async Task AddHoliday(Holiday holiday)
        {
            await _holidayService.AddHoliday(holiday);
        }

        //POST: api/AddHoliday
        /// <summary>
        /// Add holiday
        /// </summary>
        [HttpPost("Category")]
        public async Task AddCategory(int id, Category category)
        {
            await _holidayService.AddCategory(id, category);
        }


        //DELETE: api/DeleteHoliday
        /// <summary>
        /// Delete holiday 
        /// </summary>
        [HttpDelete]
        public async Task DeleteHoliday(Holiday holiday)
        {
            await _holidayService.DeleteHoliday(holiday);
        }
    }
}