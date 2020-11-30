using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public string Name;
        public string Description;
        public IEnumerable<Item> Items;
        #endregion

        #region constructor
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }
        #endregion

        #region methods

        #endregion
    }
}
