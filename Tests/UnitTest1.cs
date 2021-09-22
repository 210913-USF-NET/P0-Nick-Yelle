using System;
using Xunit;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void BrewsShouldSetValidData()
        {
            //Arrange.
            Brew test = new Brew();
            string testName = "test brew";

            //Act.
            test.name = testName;

            //Assert.
            Assert.Equal(testName, test.Name);
        }

        [Theory]
        []
        public void BrewShouldNotSetInvalidData(string input)
        {
            //Arrange.

        }
    }
}
