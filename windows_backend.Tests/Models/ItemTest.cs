using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using windows_backend.Models;
using Xunit;

namespace windows_backend.Tests.Models
{
    public class ItemTest
    {

        private readonly string _validName = "Name";

        #region Constructor

        [Fact]
        public void NewItem_ValidItem_CreatesItem()
        {
            Item item = new Item(_validName);

            Assert.Equal(_validName, item.Name);
            Assert.Empty(item.Tasks);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewItem_NonValidName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Item(name));
        }

        #endregion

        #region AddTask

        [Fact]
        public void AddTask_ValidTask_AddsTask()
        {
            ItemTask task = new ItemTask();
            Item item = new Item();

            item.AddTask(task);

            Assert.NotEmpty(item.Tasks);
        }

        [Fact]
        public void AddTask_NonValidTask_ThrowsArgumentException()
        {
            ItemTask task = new ItemTask();
            Item item = new Item();

            item.AddTask(task);

            Assert.Throws<ArgumentException>(() => item.AddTask(task));
        }

        #endregion

        #region EditTask

        [Fact]
        public void EditItem_ValidItem_EditsItem()
        {
            ItemTask task = new ItemTask();
            ItemTask newTask = new ItemTask("Description");
            Item item = new Item();

            item.AddTask(task);
            item.EditTask(task, newTask);

            Assert.True(item.Tasks.Where(i => i.Description == newTask.Description).Any());
        }

        [Fact]
        public void EditItem_NonValidItem_ThrowsArgumentException()
        {
            ItemTask task = new ItemTask();
            ItemTask newTask = new ItemTask("Description");
            Item item = new Item();

            Assert.Throws<ArgumentException>(() => item.EditTask(task, newTask));
        }

        #endregion

    }
}
