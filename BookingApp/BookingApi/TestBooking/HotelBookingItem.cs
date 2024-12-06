using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestBooking
{
    public class HotelBookingItem
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("roomNumber")]
        public int roomNumber { get; set; }
        [JsonProperty("clientsName")]
        public string clientsName { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("adress")]
        public string adress { get; set; }
    }
}
