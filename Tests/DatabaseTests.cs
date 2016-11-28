using System;
using Xunit;

namespace BanagzonFinancialUnitTests
{
    public class DatabaseTest
    {
        [Fact]
        public void trueTest()
        {
            bool truthy = true;
            Assert.Equal(truthy, true);

        }
    }
}