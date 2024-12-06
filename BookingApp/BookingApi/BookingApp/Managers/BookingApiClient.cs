using BookingApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookingApp.Managers
{
    public class BookingApiClient
    {
        /// <summary>
        /// Metóda vracia zoznam všetkých rezervácií.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookingModel> GetAllBookings()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                    client.BaseAddress = new Uri("https://localhost:7127");
                    HttpResponseMessage response = client.GetAsync("/api/HotelBooking/booking").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<BookingModel> bookings = JsonConvert.DeserializeObject<List<BookingModel>>(responseBody);
                        return bookings;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metóda vracia konkrétnu rezerváciu podľa id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookingModel GetBookingById(int id)
        {
            try
            {
                //int id = 1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7127");
                    HttpResponseMessage response = client.GetAsync($"/api/HotelBooking/booking/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        BookingModel booking = JsonConvert.DeserializeObject<BookingModel>(responseBody);
                        return booking;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingModel"></param>
        /// <returns></returns>
        public BookingModel PostNewBooking(BookingModel bookingModel)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(bookingModel);
                StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7127");
                    HttpResponseMessage response = client.PostAsync("/api/HotelBooking/booking", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        BookingModel booking = JsonConvert.DeserializeObject<BookingModel>(responseBody);
                        return booking;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookingModel"></param>
        /// <returns></returns>
        public bool UpdateBooking(int id, BookingModel bookingModel) 
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7127");

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(bookingModel), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PutAsync($"/api/HotelBooking/booking/{id}", jsonContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBookingById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7127");
                    HttpResponseMessage response = client.DeleteAsync($"/api/HotelBooking/booking/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
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

