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
        public List<Parcel> OrderParcelDetails { get; set; }

        //using Linq to get the total number of parcel in a order
        public int TotalParcelInOrder => OrderParcelDetails.Count;

        //Check does this order need for fast shipping 
        public bool IsSpeedyOrder { get; set; }

        //check the order trigger order discount
        public bool OrderDiscountTrigger => CheckOrderDiscount(OrderDiscountType);

        //get discount type name
        public string OrderDiscountType => GetParcelDiscountType(OrderParcelDetails, TotalParcelInOrder);


        //Create a method to get the Parcel Discount Type
        private static string GetParcelDiscountType(List<Parcel> parcels, int totalParcel)
        {
            int TotalSmallParcel = parcels.Count(x => x.ParcelInfo.ParcelSizeName.Equals(nameof(ParcelDiscountType.Small)));
            int TotalMediumParcel = parcels.Count(x => x.ParcelInfo.ParcelSizeName.Equals(nameof(ParcelDiscountType.Medium)));

            if (totalParcel.Equals(TotalSmallParcel))
                return nameof(ParcelDiscountType.Small);
            if (totalParcel.Equals(TotalMediumParcel))
                return nameof(ParcelDiscountType.Medium);
            if (totalParcel >= (int)ParcelDiscountType.Mixed)
                return nameof(ParcelDiscountType.Medium);

            return nameof(ParcelDiscountType.None);

        }

        private static bool CheckOrderDiscount(string OrderDiscountType) => !OrderDiscountType.Equals(nameof(ParcelDiscountType.None));


    }
}
