using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Bookings {  get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }       

        //public void CreateFirstData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HotelBooking>().HasData(
        //        new HotelBooking { Id = 1, RoomNumber = 10, ClientsName = "Peter", Description = "nic", Adress = "nic" },
        //        new HotelBooking { Id = 2, RoomNumber = 20, ClientsName = "Petra", Description = "nic", Adress = "nic" },
        //        new HotelBooking { Id = 3, RoomNumber = 30, ClientsName = "Jakub", Description = "nic", Adress = "nic" }
        //    );
        //}
    }
}
