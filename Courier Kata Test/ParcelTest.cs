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

        [Theory]
        [InlineData(50, 50, 50, 500, false, 3)]//Small
        [InlineData(50, 50, 490, 500, false, 8)]//Medium
        [InlineData(50, 50, 990, 500, false, 15)]//Large
        [InlineData(50, 50, 5000, 500, false, 25)]//XL
        [InlineData(50, 50, 50, 500, true, 50)]//Heavy
        public void CheckParcelBaseFeeCorrect(int len, int wid, int hei, int wei, bool IsHeavy, int ExpectedFee)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(ExpectedFee, p.ParcelBaseFee);
        }

        [Theory]
        [InlineData(50, 50, 50, 1001, false, true)] //Small
        [InlineData(50, 490, 50, 3001, false, true)]//Medium
        [InlineData(50, 990, 50, 6001, false, true)]//Large
        [InlineData(50, 50, 5000, 10001, false, true)]//XL
        [InlineData(50, 50, 50, 500000, true, true)]//Heavy
        public void CheckParcelOverWeightTrue(int len, int wid, int hei, int wei, bool IsHeavy, bool IsOverWeight)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(IsOverWeight, p.ParcelOverWeightLimite);
        }

        [Theory]
        [InlineData(50, 50, 50, 2000, false, 1000)] //Small
        [InlineData(50, 490, 50, 8000, false, 5000)]//Medium
        [InlineData(50, 990, 50, 12000, false, 6000)]//Large
        [InlineData(50, 50, 5000, 23000, false, 13000)]//XL
        [InlineData(50, 50, 50, 55000, true, 5000)]//Heavy
        public void CheckParcelOverWeightTure(int len, int wid, int hei, int wei, bool IsHeavy, int OverWeightPerG)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(OverWeightPerG, p.ParcelOverWeight);
        }

        [Theory]
        [InlineData(50, 50, 50, 2000, false, 2)] //Small
        [InlineData(50, 490, 50, 8000, false, 10)]//Medium
        [InlineData(50, 990, 50, 12000, false, 12)]//Large
        [InlineData(50, 50, 5000, 23000, false, 26)]//XL
        [InlineData(50, 50, 50, 55000, true, 5)]//Heavy
        public void CheckParcelPenaltyFee(int len, int wid, int hei, int wei, bool IsHeavy, int PenaltyFee)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(PenaltyFee, p.ParcelPenaltyFee);
        }

        [Theory]
        [InlineData(50, 50, 50, 2000, false, 5)] //Small
        [InlineData(50, 490, 50, 8000, false, 18)]//Medium
        [InlineData(50, 990, 50, 12000, false, 27)]//Large
        [InlineData(50, 50, 5000, 23000, false, 51)]//XL
        [InlineData(50, 50, 50, 55000, true, 55)]//Heavy
        public void CheckParcelPrice(int len, int wid, int hei, int wei, bool IsHeavy, int PenaltyPlusPackageFee)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(PenaltyPlusPackageFee, p.ParcelTotalCostWithPenaltyFee);
        }

        [Theory]
        [InlineData(50, 50, 50, 500, false, 100)]
        [InlineData(50, 400, 50, 500, false, 500)]
        [InlineData(50, 990, 50, 500, false, 1000)]
        [InlineData(50, 50, 5000, 500, false, 0)]
        [InlineData(50, 50, 5000, 500, true, 0)]
        public void ParcelInfoSizeDimensionsTest(int len, int wid, int hei, int wei, bool IsHeavy, int SizeDimensions)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(SizeDimensions, p.ParcelInfo.ParcelSizedimensions_mm);
        }

        [Theory]
        [InlineData(50, 50, 50, 500, false, 1000)]
        [InlineData(50, 400, 50, 500, false, 3000)]
        [InlineData(50, 990, 50, 500, false, 6000)]
        [InlineData(50, 50, 5000, 500, false, 10000)]
        [InlineData(50, 50, 5000, 500, true, 50000)]
        public void ParcelInfoSizeWeightLimitTest(int len, int wid, int hei, int wei, bool IsHeavy, int SizeWeightLimit)
        {
            Parcel p = new(len, wid, hei, wei, IsHeavy);
            Assert.Equal(SizeWeightLimit, p.ParcelInfo.ParcelWeightLimit_g);
        }
    }
}
