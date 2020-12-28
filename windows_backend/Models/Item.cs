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
        public Category _category;
        #endregion

        #region properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
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
        public List<ItemTask> Tasks { get; set; }
        public Category Category { set; get; }

        #endregion

        #region constructor
        public Item(string name)
        {
            Name = name;
            Tasks = new List<ItemTask>();
        }

        public Item()
        {
            Tasks = new List<ItemTask>();
        }
        #endregion

        #region methods
        public void AddTask(ItemTask task)
        {
            if (Tasks.Contains(task))
            {
                throw new ArgumentException("Task is already added.");
            }
            Tasks.Add(task);
        }

        public void EditTask(ItemTask oldTask, ItemTask newTask)
        {
            if (!Tasks.Contains(oldTask))
            {
                throw new ArgumentException("Item doesn't exist.");
            }
            oldTask.Description = newTask.Description;
            oldTask.IsDone = newTask.IsDone;
        }
        #endregion
    }
}
