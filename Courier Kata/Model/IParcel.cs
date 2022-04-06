namespace Courier_Kata.Model
{
    public interface IParcel
    {
        int Height_mm { get; set; }
        bool IsHeavy { get; set; }
        int Length_mm { get; set; }
        int ParcelBaseFee { get; }
        ParcelInfo ParcelInfo { get; }
        int ParcelOverWeight { get; }
        bool ParcelOverWeightLimite { get; }
        int ParcelPenaltyFee { get; }
        int ParcelTotalCostWithPenaltyFee { get; }
        int Weight_g { get; set; }
        int Width_mm { get; set; }

        ParcelInfo GetParcelSize();
    }
}