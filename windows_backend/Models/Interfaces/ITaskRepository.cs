using System.Collections.Generic;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface ITaskRepository
    {
        Task<ItemTask> GetBy(int id);
        Task<List<ItemTask>> GetByItem(int itemId);
        Task<List<ItemTask>> GetAll();
        Task Add(ItemTask task);
        Task Delete(ItemTask task);
        Task SaveChanges();
    }
}
