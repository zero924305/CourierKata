using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Courier_Kata.Model
{
    public class Parcel
    {
        public Parcel(int Length_mm, int Width_mm, int Height_mm, int Weight_g, bool IsHeavy)
        {
            if (Length_mm <= 0 || Width_mm <= 0 || Height_mm <= 0 || Weight_g <= 0)
                throw new InvalidOperationException("The package dimensions or weight are invalid");

            this.Length_mm = Length_mm;
            this.Width_mm = Width_mm;
            this.Height_mm = Height_mm;
            this.Weight_g = Weight_g;
            this.IsHeavy = IsHeavy;
        }

        //set the length in millimetre 
        public int Length_mm { get; set; }

        //set the Width in millimetre 
        public int Width_mm { get; set; }

        //set the Height in millimetre 
        public int Height_mm { get; set; }

        //set the Weight in gram
        public int Weight_g { get; set; }

        public bool IsHeavy { get; set; }

        //get the Parcel base Fee by Parcel size  
        public int ParcelBaseFee => ParcelInfo.ParcelSizeFee;

        //Check does the parcel overweight
        public bool ParcelOverWeightLimite => this.Weight_g > this.ParcelInfo.ParcelWeightLimit_g;

        //calculate how much over weight
        public int ParcelOverWeight => this.Weight_g - this.ParcelInfo.ParcelWeightLimit_g;

        //Get how much is the penalty fee if the parcel is over weight
        public int ParcelPenaltyFee => ParclePenaltyCost(ParcelOverWeight, ParcelInfo, ParcelOverWeightLimite);

        //Get the total cost for the parcel withe penalty 
        public int ParcelTotalCostWithPenaltyFee => ParcelBaseFee + ParcelPenaltyFee;
        //Get ParcelSize Info 
        public ParcelInfo ParcelInfo => GetParcelSize();
         
        public ParcelInfo GetParcelSize()
        {
            ParcelInfo parcelInfo = null;

            //Create a Parcel detail list 
            List<ParcelInfo> plist = new();
            //ParcelSizeName, ParcelDimensions, ParcelSizeFee, ParcelWeightLimit, ParcelOverWeightPenaltyFee
            plist.Add(new ParcelInfo("Small", 100, 3, 1000, 2));
            plist.Add(new ParcelInfo("Medium", 500, 8, 3000, 2));
            plist.Add(new ParcelInfo("Large", 1000, 15, 6000, 2));
            plist.Add(new ParcelInfo("XL", 0, 25, 10000, 2));
            plist.Add(new ParcelInfo("Heavy", 0, 50, 50000, 1));

            if (IsHeavy)
                parcelInfo = plist.First(x => x.ParcelSizeName == "Heavy");

            else
            {
                foreach (var parcel in plist.Where(x => x.ParcelSizedimensions_mm > 0))
                {
                    //Check the input of Lenght, Width, Height and define which parcel size of this parcel is
                    if (this.Length_mm < parcel.ParcelSizedimensions_mm && this.Width_mm < parcel.ParcelSizedimensions_mm && this.Height_mm < parcel.ParcelSizedimensions_mm)
                    {
                        parcelInfo = parcel;
                        break;
                    }
                }
                    //if the condiction did not match then select the parcel size is "XL" 
                    if (parcelInfo is null)
                        parcelInfo = plist.First(x => x.ParcelSizeName == "XL");
            }
                return parcelInfo;
        }

        //Create this method to calculate the penaltycost
        private static int ParclePenaltyCost(int Overweight, ParcelInfo parcelInfo, bool IsParcelOverWeight)
        {
            int OvweWeightInKg = 0;
            if (IsParcelOverWeight)
                OvweWeightInKg = (int)Math.Ceiling((double)Overweight / 1000);

            return OvweWeightInKg * parcelInfo.ParcelSizeOverWeightPenaltyFeePerKg;
        }
    }
}
