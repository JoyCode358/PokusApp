using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestTodoApi
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public async Task TestMethodPost()
        {
            HotelBookingItem p1 = new HotelBookingItem();
            p1.id = 0;
            p1.roomNumber = 2;
            p1.clientsName = "BBB";
            p1.description = "BBB";
            p1.adress = "2B";

            //p1.id = 0;
            //p1.roomNumber = 3;
            //p1.clientsName = "CCC";
            //p1.description = "CCC";
            //p1.adress = "3C";

            try
            {
                string jsonString = JsonConvert.SerializeObject(p1);
                StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7075");
                    HttpResponseMessage response = await client.PostAsync("/api/HotelBooking/booking", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        HotelBookingItem booking = JsonConvert.DeserializeObject<HotelBookingItem>(responseBody);
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }   
        }

        [TestMethod]
        public async Task TestMethodGetAll()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7075");
                    HttpResponseMessage response = await client.GetAsync("/api/HotelBooking/booking");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<HotelBookingItem> booking = JsonConvert.DeserializeObject<List<HotelBookingItem>>(responseBody);
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                } 
            }
            catch (Exception)
            {
                throw;
            } 
        }

        [TestMethod]
        public async Task TestMethodGetById()
        {
            try
            {
                int id = 1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7075");
                    HttpResponseMessage response = await client.GetAsync($"/api/HotelBooking/booking/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        HotelBookingItem booking = JsonConvert.DeserializeObject<HotelBookingItem>(responseBody);
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }   
        }

        [TestMethod]
        public async Task TestMethodDelete()
        {
            try
            {
                int id = 1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7075");
                    HttpResponseMessage response = await client.DeleteAsync($"/api/HotelBooking/booking/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }   
            }
            catch (Exception)
            {
                throw;
            } 
        }

        [TestMethod]
        public async Task TestMethodPut()
        {
            HotelBookingItem p1 = new HotelBookingItem();
            p1.id = 1;
            p1.roomNumber = 21;
            p1.clientsName = "Boris";
            p1.description = "Náročný";
            p1.adress = "32A";

            try
            {
                string jsonString = JsonConvert.SerializeObject(p1);
                StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                int id = 1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7075");
                    HttpResponseMessage response = await client.PutAsync($"/api/HotelBooking/booking/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        HotelBookingItem booking = JsonConvert.DeserializeObject<HotelBookingItem>(responseBody);
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }  
            }
            catch (Exception)
            {
                throw;
            }  
        }
    }
}
