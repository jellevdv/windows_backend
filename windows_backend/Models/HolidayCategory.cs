using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models
{
    public class HolidayCategory
    {

        #region Properties
        public int HolidayId { get; set; }
        public int CategoryId { get; set; }
        public Holiday Holiday { get; set; }
        public Category Category { get; set; }
        #endregion

        #region Constructor
        public HolidayCategory() { }

        public HolidayCategory(Holiday holiday, Category category)
        {
            HolidayId = holiday.Id;
            CategoryId = category.Id;
            Holiday = holiday;
            Category = category;
        }
        #endregion




    }
}
