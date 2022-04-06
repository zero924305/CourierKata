using System;
using Xunit;
using Courier_Kata.Model;

namespace Courier_Kata_Test
{
    public class ParcelTest
    {
        [Theory]
        [InlineData(1, 0, 1, 1,false)]
        [InlineData(1, 1, 0, 1, false)]
        [InlineData(1, 1, 1, 0, false)]
        [InlineData(0, 1, 1, 1, false)]
        public void CheckParcelConstructorsThrowInvalidError(int len, int wid, int hei, int wei,bool isHeavy)
        {
            Assert.Throws<InvalidOperationException>(() => { new Parcel(len, wid, hei, wei, isHeavy); });
        }
    }
}
