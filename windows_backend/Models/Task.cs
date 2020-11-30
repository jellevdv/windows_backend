using System.ComponentModel.DataAnnotations.Schema;

namespace windows_backend.Models
{
    public class Task
    {
        #region fiels
        public string _description;
        public bool _isDone;
        #endregion

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        #endregion

        #region constructor
        public Task(string description)
        {
            Description = description;
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
