using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courier_Kata.Model
{
    public class Order
    {
        public List<Parcel> ParcelDetails { get; set; }
        //using Linq to get the total number of parcel in a order
        public int TotalParcelInOrder => ParcelDetails.Count;


    }
}
