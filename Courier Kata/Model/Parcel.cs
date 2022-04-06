using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courier_Kata.Model
{
    //Parcel Size Details
    public enum ParcelSize
    { 
        Small = 10,
        Medium = 50, 
        Large = 100,
        XL
    }


    public class Parcel
    {
        public Parcel(int len, int wid, int hei,int wei)
        {
            if (len <= 0 || wid <= 0 || hei <= 0 || wei <= 0)
                throw new InvalidOperationException("The package dimensions or weight are invalid");

            this.Length_mm = len;
            this.Width_mm = wid;
            this.Height_mm = hei;
            this.Weight_g = wei;
        }

        //set the length in millimetre 
        public int Length_mm { get; set; }

        //set the Width in millimetre 
        public int Width_mm { get; set; }

        //set the Height in millimetre 
        public int Height_mm { get; set; }

        //set the Weight in gram
        public int Weight_g { get; set; }

    }
}
