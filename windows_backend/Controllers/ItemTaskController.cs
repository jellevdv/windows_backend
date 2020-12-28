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
    public class ItemTaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;

        public ItemTaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        // GET: api/Tasks
        /// <summary>
        /// Get all Tasks 
        /// </summary>
        /// <returns>array of Tasks</returns>
        [HttpGet]
        public async Task<IEnumerable<ItemTask>> GetTasks()
        {
            try
            {
                return await _taskRepo.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Tasks not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetTaskById
        /// <summary>
        /// Get Task by id 
        /// </summary>
        /// <returns>Task</returns>
        [HttpGet("Task")]
        public async Task<ItemTask> GetTaskById(int TaskId)
        {
            try
            {
                return await _taskRepo.GetBy(TaskId);
            }
            catch (Exception e)
            {
                BadRequest("Task not found! " + e.Message);
                return null;
            }
        }

        //POST: api/AddTask
        /// <summary>
        /// Add Task
        /// </summary>
        [HttpPost]
        public async Task AddTask(ItemTask itemTask)
        {
            try
            {
                await _taskRepo.Add(itemTask);
            }
            catch (Exception e)
            {
                BadRequest("Task not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteTask
        /// <summary>
        /// Delete Task 
        /// </summary>
        [HttpDelete]
        public async Task DeleteTask(ItemTask itemTask)
        {
            try
            {
                await _taskRepo.Delete(itemTask);
            }
            catch (Exception e)
            {
                BadRequest("Task not deleted! " + e.Message);
            }
        }
    }
}