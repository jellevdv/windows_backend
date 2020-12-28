using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace windows_backend.Models
{
    public class ItemTask
    {
        #region fiels
        public string _description;
        public bool _isDone;
        public Item _item;
        #endregion

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ItemId { get; set; }
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
        public bool IsDone { get; set; }
        public Item Item { get; set; }
        #endregion

        #region constructor
        public ItemTask(string description)
        {
            Description = description;
            IsDone = false;
        }

        public ItemTask()
        {
            IsDone = false;
        }
        #endregion

        #region methods
        public void TaskChecked()
        {
            switch (IsDone)
            {
                case true:
                    {
                        IsDone = false;
                        break;
                    }
                case false:
                    {
                        IsDone = true;
                        break;
                    }
            }

        }
        #endregion
    }
}
