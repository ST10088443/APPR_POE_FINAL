using Disaster_Alleviation_Foundation_App.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaster_Alleviation_Foundation_App.Tests
{
    public class DisasterTests
    {
        [Fact]
        public void IsActive_Should_Be_True_For_Future_Disaster()
        {
            // Arrange
            var futureDisaster = new Disaster
            {
                StartDate = DateTime.Now.AddHours(1), // A future start date
                EndDate = DateTime.Now.AddHours(2),   // A future end date
            };

            // Act
            var isActive = futureDisaster.IsActive;

            // Assert
            Assert.True(isActive, "Disaster should be active for future dates.");
        }

        [Fact]
        public void IsActive_Should_Be_False_For_Past_Disaster()
        {
            // Arrange
            var pastDisaster = new Disaster
            {
                StartDate = DateTime.Now.AddHours(-2), // A past start date
                EndDate = DateTime.Now.AddHours(-1),   // A past end date
            };

            // Act
            var isActive = pastDisaster.IsActive;

            // Assert
            Assert.False(isActive, "Disaster should not be active for past dates.");
        }
    }

    public class GoodsCategoryTests
    {
        [Fact]
        public void GoodsCategory_Name_Should_Not_Be_Null_Or_Empty()
        {
            // Arrange
            var goodsCategory = new GoodsCategory
            {
                Name = "Clothes" // Replace with the appropriate name
            };

            // Act
            var nameIsValid = !string.IsNullOrEmpty(goodsCategory.Name);

            // Assert
            Assert.True(nameIsValid, "GoodsCategory name should not be null or empty.");
        }
    }
}
