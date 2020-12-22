using System;
using System.Collections.Generic;
using System.Text;
using windows_backend.Models;
using Xunit;

namespace windows_backend.Tests.Models
{
    public class ItemTaskTest
    {

        private readonly string _validDescription = "Description";

        #region Constructor

        [Fact]
        public void NewItemTask_ValidItemTask_CreatesItemTask()
        {
            ItemTask itemTask = new ItemTask(_validDescription);

            Assert.Equal(_validDescription, itemTask.Description);
            Assert.False(itemTask.IsDone);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewItemTask_NonValidDescription_ThrowsArgumentException(string description)
        {
            Assert.Throws<ArgumentException>(() => new ItemTask(description));
        }

        #endregion

        #region TaskChecked

        [Fact]
        public void TaskChecked_IsDoneChanges()
        {
            ItemTask itemTask = new ItemTask();

            itemTask.TaskChecked();

            Assert.True(itemTask.IsDone);
        }

        #endregion


    }
}
