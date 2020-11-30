using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetBy(int id);
        Task<List<Item>> GetByCategory(int categoryId);
        Task<List<Item>> GetAll();
        Task Add(Item item);
        Task Delete(Item item);
        Task SaveChanges();
    }
}
