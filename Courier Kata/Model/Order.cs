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

    public class Order: IOrder
    {
        public List<Parcel> OrderParcelDetails { get; set; }

        //Check does this order need for fast shipping 
        public bool IsSpeedyOrder { get; set; }

        //using Linq to get the total number of parcel in a order
        public int TotalParcelInOrder => OrderParcelDetails.Count;

        //check the order trigger order discount
        public bool OrderDiscountTrigger => CheckOrderDiscount(OrderDiscountType);

        //get discount type name
        public string OrderDiscountType => GetParcelDiscountType(OrderParcelDetails, TotalParcelInOrder);

        //Get the stander order shipping fee
        public int StanderOrderShippingFee => GetStanderShippingFee(OrderParcelDetails) - ParcelDiscountFee;

        //Get the speedy order shipping fee
        public int SpeedyOrderShippingFee => (IsSpeedyOrder?GetSpeedyFee(IsSpeedyOrder,OrderParcelDetails) - ParcelDiscountFee:0);

        public int TotalFreeParcelInOrder => GetTotalFreeParcel(OrderDiscountType, TotalParcelInOrder, OrderDiscountTrigger);

        //calculate the lowest price as discount for this order if the order discount is trigger
        public int ParcelDiscountFee => GetParcelDiscount(OrderParcelDetails, TotalFreeParcelInOrder);

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

        //Calculate stander shipping fee
        private static int GetStanderShippingFee(List<Parcel> parcels) => parcels.Sum(x => x.ParcelTotalCostWithPenaltyFee);

        //Calculate Speedy shipping fee
        private static int GetSpeedyFee(bool IsSpeedy, List<Parcel> parcels) => (IsSpeedy ? parcels.Sum(x => x.ParcelTotalCostWithPenaltyFee) * 2 : 0);

        private static int GetTotalFreeParcel(string OrderDiscountName, int totalParcel, bool checkOrderTirgger)
        {
            int FreeParcel = 0;
            if (!checkOrderTirgger)
                return FreeParcel;

            FreeParcel = OrderDiscountName switch
            {
                nameof(ParcelDiscountType.Small) => Math.DivRem(totalParcel, (int)ParcelDiscountType.Small, out _),
                nameof(ParcelDiscountType.Medium) => Math.DivRem(totalParcel, (int)ParcelDiscountType.Medium, out _),
                nameof(ParcelDiscountType.Mixed) => Math.DivRem(totalParcel, (int)ParcelDiscountType.Mixed, out _),
                _ => 0,
            };

            return FreeParcel;
        }

        private static int GetParcelDiscount(List<Parcel> parcels, int TotalFreeParcel) => parcels.OrderBy(x => x.ParcelTotalCostWithPenaltyFee).Take(TotalFreeParcel).Sum(x => x.ParcelTotalCostWithPenaltyFee);
    }
}
