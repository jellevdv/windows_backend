using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace windows_backend.Models
{
    public class Category
    {
        #region fields
        public string _name;
        public string _description;
        public IEnumerable<Item> _items;
        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public IEnumerable<Holiday> Holidays { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Item> Items { get; set; }
        #endregion

        #region constructor
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Holidays = new List<Holiday>();
        }
        #endregion

        #region methods
        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void EditItem()
        {
            throw new NotImplementedException();
        }

        public void AsignToHolidays(Holiday holiday)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
