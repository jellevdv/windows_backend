using System;
using System.Collections.Generic;

namespace windows_backend.Models
{
    public class Holiday
    {
        #region fields
        public string _name;
        public string _description;
        public string _destination;
        public IEnumerable<User> _users;
        public IEnumerable<Category> _categories;
        public DateTime _departuredate;


        #endregion
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime DepartureDate;
        #endregion

        #region constructor
        public Holiday(string name,string destination, string description, DateTime departuredate)
        {
            Name = name;
            Description = description;
            Destination = destination;
            Users = new List<User>();
            Categories = new List<Category>();
            DepartureDate = departuredate;
        }
        #endregion

        #region methods

        #endregion

    }
}
