using System;
using Xunit;
using Courier_Kata.Model;

namespace Courier_Kata_Test
{
    public class ParcelTest
    {
        [Theory]
        [InlineData(1, 0, 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 1, 1, 0)]
        [InlineData(0, 1, 1, 1)]
        public void CheckParcelConstructorsThrowInvalidError(int len, int wid, int hei, int wei)
        {
            Assert.Throws<InvalidOperationException>(() => { new Parcel(len, wid, hei, wei); });
        }
    }
}
