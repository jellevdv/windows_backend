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
    [Produces("application/json")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/Items
        /// <summary>
        /// Get all items 
        /// </summary>
        /// <returns>array of items</returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetItems()
        {
            try
            {
                return await _itemRepository.GetAll();
            }
            catch (Exception e)
            {
                BadRequest("Items not found! " + e.Message);
                return null;
            }
        }

        //GET: api/GetItemById
        /// <summary>
        /// Get Item by id 
        /// </summary>
        /// <returns>Item</returns>
        [HttpGet("Item")]
        public async Task<Item> GetItemById(int itemId)
        {
            try
            {
                return await _itemRepository.GetBy(itemId);
            }
            catch (Exception e)
            {
                BadRequest("Item not found! " + e.Message);
                return null;
            }
        }

        //POST: api/AddItem
        /// <summary>
        /// Add Item
        /// </summary>
        [HttpPost]
        public async Task AddItem(Item Item)
        {
            try
            {
                await _itemRepository.Add(Item);
            }
            catch (Exception e)
            {
                BadRequest("Item not added! " + e.Message);
            }
        }


        //DELETE: api/DeleteItem
        /// <summary>
        /// Delete Item 
        /// </summary>
        [HttpDelete]
        public async Task DeleteItem(Item Item)
        {
            try
            {
                await _itemRepository.Delete(Item);
            }
            catch (Exception e)
            {
                BadRequest("Item not deleted! " + e.Message);
            }
        }
    }
}