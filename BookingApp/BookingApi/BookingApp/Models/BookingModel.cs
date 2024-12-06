﻿using System.ComponentModel.DataAnnotations;

namespace BookingApp.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string? ClientsName { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; }

        public BookingModel()
        { } 
    }
}