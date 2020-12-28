using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace windows_backend.Models
{
    public class Holiday
    {
        #region fields
        public string _name;
        public string _description;
        public string _destination;
        public DateTime _departuredate;
        #endregion

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public string Destination {
            get
            {
                return _destination;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Destination can't be empty");
                }
                _destination = value;
            }
        }
        public List<User> Users { get; set; }
        public List<HolidayCategory> Categories { get; set; }
        public DateTime DepartureDate { get; set; }
        #endregion

        #region constructor
        public Holiday(string name, string destination, string description, DateTime departuredate)
        {
            Name = name;
            Description = description;
            Destination = destination;
            Users = new List<User>();
            Categories = new List<HolidayCategory>();
            DepartureDate = departuredate;
        }

        public Holiday()
        {
            Users = new List<User>();
            Categories = new List<HolidayCategory>();
        }
        #endregion

        #region methods
        public void AddCategory(Category category)
        {
            if (Categories.Where(c => c.CategoryId == category.Id).Any())
            {
                throw new ArgumentException("Category is already added.");
            }
            HolidayCategory holidayCategory = new HolidayCategory(this, category);
            Categories.Add(holidayCategory);
            category.Holidays.Add(holidayCategory);
        }

        public void AddUser(User user)
        {
            if (Users.Contains(user))
            {
                throw new ArgumentException("Category is already added.");
            }
            Users.Add(user);
        }
        #endregion

    }
}
