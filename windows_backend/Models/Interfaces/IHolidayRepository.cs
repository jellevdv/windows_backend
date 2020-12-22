using System.Collections.Generic;
using System.Threading.Tasks;

namespace windows_backend.Models.Interfaces
{
    public interface IHolidayRepository
    {
        Task<Holiday> GetBy(int id);
        Task<List<Holiday>> GetAll();
        Task Add(Holiday holiday);
        Task Delete(Holiday holiday);
        Task SaveChanges();
    }
}
