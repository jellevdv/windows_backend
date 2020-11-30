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
        public IEnumerable<Task> _tasks;
        #endregion

        #region properties
        public string Name;
        public IEnumerable<Task> Tasks;
        #endregion

        #region constructor
        public Item(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }
        #endregion

        #region methods
        public void addTask(Task task)
        {
            Tasks.Append(task);
        }

        #endregion
    }
}
