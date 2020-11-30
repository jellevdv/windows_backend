using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace windows_backend.Models
{
    public class Item
    {
        #region fields
        public string _name;
        public IEnumerable<ItemTask> _tasks;
        public Category _category;
        #endregion

        #region properties
        public string Name { set; get; }
        public Category Category { set; get; }
        public IEnumerable<ItemTask> Tasks { set; get; }
        #endregion

        #region constructor
        public Item(string name)
        {
            Name = name;
            Tasks = new List<ItemTask>();
        }
        #endregion

        #region methods
        public void addTask(ItemTask task)
        {
            Tasks.Append(task);
        }

        #endregion
    }
}
