using System;
namespace BookingRecordApi.Models
{
    public class BookingRecordItem
    {
       public DateTime datetime { get; set; }
       public string Date { get; set; }
       public string Time { get; set; }
       public string PickupPoint { get; set; }
       public string Destination { get; set; }
       public float CurrentLocationLat { get; set; }
       public float CurrentLocationLon { get; set; }

    }
}
