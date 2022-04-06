namespace Courier_Kata.Model
{
    public interface IParcelInfo
    {
        int ParcelSizedimensions_mm { get; set; }
        int ParcelSizeFee { get; set; }
        string ParcelSizeName { get; set; }
        int ParcelSizeOverWeightPenaltyFeePerKg { get; set; }
        int ParcelWeightLimit_g { get; set; }
    }
}