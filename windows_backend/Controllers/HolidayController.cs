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
        private readonly IHolidayRepository _holidayRepo;

        public HolidayController(IHolidayRepository holidayRepo)
        {
            _holidayRepo = holidayRepo;
        }

        // GET: api/Holidays
        /// <summary>
        /// Get all holidays 
        /// </summary>
        /// <returns>array of holidays</returns>
        [HttpGet]
        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            try
            {
                return await _holidayRepo.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Holidays not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetHolidayById
        /// <summary>
        /// Get holiday by id 
        /// </summary>
        /// <returns>holiday</returns>
        [HttpGet("Holiday")]
        public async Task<Holiday> GetHolidayById(int holidayId)
        {
            try
            {
                return await _holidayRepo.GetBy(holidayId);
            }
            catch (Exception e)
            {
                BadRequest("Holiday not found! " + e.Message);
                return null;
            }
        }

        //POST: api/AddHoliday
        /// <summary>
        /// Add holiday
        /// </summary>
        [HttpPost]
        public async Task AddHoliday(Holiday holiday)
        {
            try
            {
                await _holidayRepo.Add(holiday);
            }
            catch (Exception e)
            {
                BadRequest("Holiday not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteHoliday
        /// <summary>
        /// Delete holiday 
        /// </summary>
        [HttpDelete]
        public async Task DeleteHoliday(Holiday holiday)
        {
            try
            {
                await _holidayRepo.Delete(holiday);
            }
            catch (Exception e)
            {
                BadRequest("Holiday not deleted! " + e.Message);
            }
        }

    }
}