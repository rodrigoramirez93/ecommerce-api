using System;
using Xunit;

namespace Ecommerce.Core.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var roles = new Roles[2] { Roles.Admin, Roles.Employee };

            //act
            var result = HelperMethods.GetNames(roles);

            //assert
            Assert.Equal(2, result.Count);
        }
    }
}
