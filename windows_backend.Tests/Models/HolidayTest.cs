using System;
using System.Collections.Generic;
using System.Text;
using windows_backend.Models;
using Xunit;

namespace windows_backend.Tests.Models
{
    public class HolidayTest
    {

        private readonly string _validName = "Name";
        private readonly string _validDescription = "Description";
        private readonly string _validDestination = "Destination";
        private readonly DateTime _validDeparture = new DateTime(2020, 1, 1);

        #region Constructor

        [Fact]
        public void NewHoliday_ValidHoliday_CreatesHoliday()
        {
            Holiday holiday = new Holiday(
                _validName,
                _validDestination, 
                _validDescription,
                _validDeparture
            );

            Assert.Equal(_validName, holiday.Name);
            Assert.Equal(_validDestination, holiday.Destination);
            Assert.Equal(_validDescription, holiday.Description);
            Assert.Equal(_validDeparture, holiday.DepartureDate);
            Assert.Empty(holiday.Users);
            Assert.Empty(holiday.Categories);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewHoliday_NonValidName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Holiday(
                name,
                _validDestination,
                _validDescription,
                _validDeparture
            ));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewHoliday_NonValidDestination_ThrowsArgumentException(string destination)
        {
            Assert.Throws<ArgumentException>(() => new Holiday(
                _validName,
                destination,
                _validDescription,
                _validDeparture
            ));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewHoliday_NonValidDescription_ThrowsArgumentException(string description)
        {
            Assert.Throws<ArgumentException>(() => new Holiday(
                _validName,
                _validDestination,
                description,
                _validDeparture
            ));
        }

        #endregion

        #region AddCategory

        [Fact]
        public void AddCategory_ValidCategory_AddsCategory()
        {
            Holiday holiday = new Holiday();
            Category category = new Category();

            holiday.AddCategory(category);

            Assert.NotEmpty(holiday.Categories);
        }

        [Fact]
        public void AddCategory_NonValidCategory_ThrowsArgumentException()
        {
            Holiday holiday = new Holiday();
            Category category = new Category();

            holiday.AddCategory(category);

            Assert.Throws<ArgumentException>(() => holiday.AddCategory(category));
        }
        #endregion

        #region AddUser

        [Fact]
        public void AddUser_ValidUser_AddsUser()
        {
            Holiday holiday = new Holiday();
            User user = new User();

            holiday.AddUser(user);

            Assert.NotEmpty(holiday.Users);
        }

        [Fact]
        public void AddUser_NonValidUser_ThrowsArgumentException()
        {
            Holiday holiday = new Holiday();
            User user = new User();

            holiday.AddUser(user);

            Assert.Throws<ArgumentException>(() => holiday.AddUser(user));
        }

        #endregion

    }
}
