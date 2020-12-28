using System;
using windows_backend.Models;
using Xunit;
using System.Linq;

namespace windows_backend.Tests.Models
{
    public class CategoryTest
    {
        private readonly string _validName = "Name";
        private readonly string _validDescription = "Description";

        #region Constructor

        [Fact]
        public void NewCategory_ValidCategory_CreatesCategory()
        {
            Category category = new Category(_validName, _validDescription);

            Assert.Equal(_validName, category.Name);
            Assert.Equal(_validDescription, category.Description);
            Assert.Empty(category.Holidays);
            Assert.Empty(category.Items);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewCategory_NonValidName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Category(name, _validDescription));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewCategory_NonValidDescription_ThrowsArgumentException(string description)
        {
            Assert.Throws<ArgumentException>(() => new Category(_validName, description));
        }
        #endregion

        #region AddItem

        [Fact]
        public void AddItem_ValidItem_AddsItem()
        {
            Item item = new Item();
            Category category = new Category();

            category.AddItem(item);

            Assert.NotEmpty(category.Items);
        }

        [Fact]
        public void AddItem_NonValidItem_ThrowsArgumentException()
        {
            Item item = new Item();
            Category category = new Category();

            category.AddItem(item);

            Assert.Throws<ArgumentException>(() => category.AddItem(item));
        }

        #endregion

        #region EditItem

        [Fact]
        public void EditItem_ValidItem_EditsItem()
        {
            Item item = new Item();
            Item newItem = new Item(_validName);
            Category category = new Category();

            category.AddItem(item);
            category.EditItem(item, newItem);

            Assert.True(category.Items.Where(i => i.Name == newItem.Name).Any());
        }

        [Fact]
        public void EditItem_NonValidItem_ThrowsArgumentException()
        {
            Item item = new Item();
            Item newItem = new Item(_validName);
            Category category = new Category();

            Assert.Throws<ArgumentException>(() => category.EditItem(item, newItem));
        }

        #endregion
    }
}
