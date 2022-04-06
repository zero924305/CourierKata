using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courier_Kata.Model
{
    //ParcelInfo store ParcelSize Details
    public class ParcelInfo
    {
        public string ParcelSizeName { get; set; }
        public int ParcelSizedimensions_mm { get; set; }
        public int ParcelWeightLimit_g { get; set; }
        public int ParcelSizeFee { get; set; }
        public int ParcelSizeOverWeightPenaltyFeePerKg { get; set; }

        public ParcelInfo(string ParcelSizeName, int ParcelSizedimensions_mm, int ParcelWeightLimit_g, int ParcelSizeFee,int ParcelSizeOverWeightPenaltyFeePerKg)
        {
            this.ParcelSizeName = ParcelSizeName;
            this.ParcelSizedimensions_mm = ParcelSizedimensions_mm;
            this.ParcelWeightLimit_g = ParcelWeightLimit_g;
            this.ParcelSizeFee = ParcelSizeFee;
            this.ParcelSizeOverWeightPenaltyFeePerKg = ParcelSizeOverWeightPenaltyFeePerKg;
        }
    }
}
