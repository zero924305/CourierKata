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

        [Theory]
        [InlineData(50, 50, 50, 500, false, "Small")]
        [InlineData(50, 50, 99, 500, false, "Small")]
        [InlineData(50, 99, 50, 500, false, "Small")]
        [InlineData(99, 99, 50, 500, false, "Small")]
        [InlineData(50, 400, 50, 500, false, "Medium")]
        [InlineData(50, 990, 50, 500, false, "Large")]
        [InlineData(50, 50, 5000, 500, false, "XL")]
        [InlineData(50, 50, 50, 5000, true, "Heavy")]
        public void CheckParclSizeNameCorrect(int len, int wid, int hei, int wei, bool IsHeavy, string ExpectName)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(ExpectName, p.ParcelInfo.ParcelSizeName);
        }

    }
}
