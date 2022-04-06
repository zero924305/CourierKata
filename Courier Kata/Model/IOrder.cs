using System.Collections.Generic;

namespace Courier_Kata.Model
{
    public interface IOrder
    {
        bool IsSpeedyOrder { get; set; }
        bool OrderDiscountTrigger { get; }
        string OrderDiscountType { get; }
        List<Parcel> OrderParcelDetails { get; set; }
        int ParcelDiscountFee { get; }
        int SpeedyOrderShippingFee { get; }
        int StanderOrderShippingFee { get; }
        int TotalFreeParcelInOrder { get; }
        int TotalParcelInOrder { get; }
    }
}