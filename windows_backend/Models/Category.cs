using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace windows_backend.Models
{
    public class Category
    {
        #region fields
        public string _name;
        public string _description;
        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public List<Holiday> Holidays { get; set; }
        public string Name {
            get
            {
                return _name;
            }
            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                _name = value;
            } 
        }
        public string Description {
            get
            {
                return _description;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description can't be empty");
                }
                _description = value;
            }
        }
        public List<Item> Items { get; set; }
        #endregion

        #region constructor
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Holidays = new List<Holiday>();
        }

        public Category()
        {
            Items = new List<Item>();
            Holidays = new List<Holiday>();
        }
        #endregion

        #region methods
        public void AddItem(Item item)
        {
            if (Items.Contains(item))
            {
                throw new ArgumentException("Item is already added.");
            }
            Items.Add(item);
        }

        public void EditItem(Item oldItem, Item newItem)
        {
            if (!Items.Contains(oldItem))
            {
                throw new ArgumentException("Item doesn't exist.");
            }
            oldItem.Name = newItem.Name;
            oldItem.Tasks = newItem.Tasks;
        }

        public void AsignToHoliday(Holiday holiday)
        {
            if (Holidays.Contains(holiday))
            {
                throw new ArgumentException("Holiday is already added.");
            }
            Holidays.Add(holiday);
        }
        #endregion
    }
}
