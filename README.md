# CourierKata
A code library to calculate the cost of sending an order of parcels

Test 1 - 
Enter the Parcel detail on Parcel, e.g. lenght_mm = 50, Width_mm = 50, Height_mm = 50, Wight_g = 500, IsHeavy = false; 
Result:

{
  "length_mm": 50,
  "width_mm": 50,
  "height_mm": 50,
  "weight_g": 500,
  "isHeavy": false,
  "parcelBaseFee": 3,
  "parcelOverWeightLimite": false,
  "parcelOverWeight": -500,
  "parcelPenaltyFee": 0,
  "parcelTotalCostWithPenaltyFee": 3,
  "parcelInfo": {
    "parcelSizeName": "Small",
    "parcelSizedimensions_mm": 100,
    "parcelSizeFee": 3,
    "parcelWeightLimit_g": 1000,
    "parcelSizeOverWeightPenaltyFeePerKg": 2
  }
}

Test 2
Use Json Array for input order, you can find a json file name orderDetailExample.json for testing.

retusl: 
{
  "orderParcelDetails": [
    {
      "length_mm": 5,
      "width_mm": 5,
      "height_mm": 5,
      "weight_g": 55,
      "isHeavy": false,
      "parcelBaseFee": 3,
      "parcelOverWeightLimite": false,
      "parcelOverWeight": -945,
      "parcelPenaltyFee": 0,
      "parcelTotalCostWithPenaltyFee": 3,
      "parcelInfo": {
        "parcelSizeName": "Small",
        "parcelSizedimensions_mm": 100,
        "parcelSizeFee": 3,
        "parcelWeightLimit_g": 1000,
        "parcelSizeOverWeightPenaltyFeePerKg": 2
      }
    },
    {
      "length_mm": 15,
      "width_mm": 15,
      "height_mm": 15,
      "weight_g": 1355,
      "isHeavy": false,
      "parcelBaseFee": 3,
      "parcelOverWeightLimite": true,
      "parcelOverWeight": 355,
      "parcelPenaltyFee": 2,
      "parcelTotalCostWithPenaltyFee": 5,
      "parcelInfo": {
        "parcelSizeName": "Small",
        "parcelSizedimensions_mm": 100,
        "parcelSizeFee": 3,
        "parcelWeightLimit_g": 1000,
        "parcelSizeOverWeightPenaltyFeePerKg": 2
      }
    },
    {
      "length_mm": 25,
      "width_mm": 25,
      "height_mm": 25,
      "weight_g": 3355,
      "isHeavy": false,
      "parcelBaseFee": 3,
      "parcelOverWeightLimite": true,
      "parcelOverWeight": 2355,
      "parcelPenaltyFee": 6,
      "parcelTotalCostWithPenaltyFee": 9,
      "parcelInfo": {
        "parcelSizeName": "Small",
        "parcelSizedimensions_mm": 100,
        "parcelSizeFee": 3,
        "parcelWeightLimit_g": 1000,
        "parcelSizeOverWeightPenaltyFeePerKg": 2
      }
    },
    {
      "length_mm": 45,
      "width_mm": 45,
      "height_mm": 45,
      "weight_g": 5555,
      "isHeavy": false,
      "parcelBaseFee": 3,
      "parcelOverWeightLimite": true,
      "parcelOverWeight": 4555,
      "parcelPenaltyFee": 10,
      "parcelTotalCostWithPenaltyFee": 13,
      "parcelInfo": {
        "parcelSizeName": "Small",
        "parcelSizedimensions_mm": 100,
        "parcelSizeFee": 3,
        "parcelWeightLimit_g": 1000,
        "parcelSizeOverWeightPenaltyFeePerKg": 2
      }
    },
    {
      "length_mm": 15,
      "width_mm": 5,
      "height_mm": 55,
      "weight_g": 22355,
      "isHeavy": true,
      "parcelBaseFee": 50,
      "parcelOverWeightLimite": false,
      "parcelOverWeight": -27645,
      "parcelPenaltyFee": 0,
      "parcelTotalCostWithPenaltyFee": 50,
      "parcelInfo": {
        "parcelSizeName": "Heavy",
        "parcelSizedimensions_mm": 0,
        "parcelSizeFee": 50,
        "parcelWeightLimit_g": 50000,
        "parcelSizeOverWeightPenaltyFeePerKg": 1
      }
    }
  ],
  "isSpeedyOrder": false,
  "totalParcelInOrder": 5,
  "orderDiscountTrigger": true,
  "orderDiscountType": "Medium",
  "standerOrderShippingFee": 77,
  "speedyOrderShippingFee": 0,
  "totalFreeParcelInOrder": 1,
  "parcelDiscountFee": 3
}
