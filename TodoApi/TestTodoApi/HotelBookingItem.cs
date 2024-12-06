using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTodoApi
{

    //public class Booking
    //{
    //    public List<HotelBookingItem> booking { get; set; }
    //}

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
