using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courier_Kata.Model
{
    public enum ParcelDiscountType { 
        None = 0,
        //Every 4 small parcel can get the discount
        Small = 4,
        //Every 3 Medium parcel can get the discount
        Medium = 3,
        //In mixed order, every 5 parcel can get the discount
        Mixed = 5
    }

    public class Order
    {
        public List<Parcel> ParcelDetails { get; set; }

        //using Linq to get the total number of parcel in a order
        public int TotalParcelInOrder => ParcelDetails.Count;

        //Check does this order need for fast shipping 
        public bool IsSpeedyOrder { get; set; }

        
    }
}
