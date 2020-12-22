using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemTask> Tasks { get; set; }
        public Category Category { set; get; }

        #endregion

        #region constructor
        public Item(string name)
        {
            Name = name;
            Tasks = new List<ItemTask>();
        }
        #endregion

        #region methods
        public void AddTask(ItemTask task)
        {
            Tasks.Append(task);
        }

        public void EditTask(ItemTask originalTask, ItemTask editedTask)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
