using BookingApp.Managers;
using BookingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class BookingController : Controller
    {      
        // GET: BookingController
        public ActionResult Index()
        {
            BookingApiClient bookingApiClient = new BookingApiClient();
            return View(bookingApiClient.GetAllBookings());
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            BookingApiClient bookingApiClient = new BookingApiClient();
            return View(bookingApiClient.GetBookingById(id));
        }

        //post
        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(BookingModel collection)
        {
            try
            {
                BookingApiClient bookingApiClient = new BookingApiClient();
                return RedirectToAction(nameof(Index), bookingApiClient.PostNewBooking(collection));
            }
            catch
            {
                return View();
            }
        }

        //put
        // GET: BookingController/Edit/5
        /*public ActionResult Edit(int id)
        {
            return View();
        }*/
        public ActionResult Edit(int id)
        {
            try
            {
                BookingApiClient bookingApiClient = new BookingApiClient();
                BookingModel bookingModel = bookingApiClient.GetBookingById(id);

                return View(bookingModel);
            }
            catch (Exception)
            {
                throw;
            } 
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookingModel collection)
        {
            try
            {
                BookingApiClient bookingApiClient = new BookingApiClient();
                return RedirectToAction(nameof(Index), bookingApiClient.UpdateBooking(id, collection));
            }
            catch
            {
                return View();
            }
        }

        //delete
        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            BookingApiClient bookingApiClient = new BookingApiClient();
            return View(bookingApiClient.GetBookingById(id));
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string clientsName)
        {
            try
            {
                BookingApiClient bookingApiClient = new BookingApiClient();
                bookingApiClient.DeleteBookingById(id);
                //return View(bookingApiClient.GetAllBookings());
                return RedirectToAction(nameof(Index),bookingApiClient.GetAllBookings());
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteModal()
        {
            return PartialView();
        }

    }
}
