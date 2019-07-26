using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessComLibraryAPI.UnitTests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void FromUnixTime_ReturnsDateTime()
        {
            var result =  Utilities.Utilities.FromUnixTime(1561538674);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ToUnixTime_ReturnsLong()
        {
            var result = Utilities.Utilities.ToUnixTime(new DateTime(2019, 12, 12));
            Assert.IsNotNull(result);
        }
    }
}
