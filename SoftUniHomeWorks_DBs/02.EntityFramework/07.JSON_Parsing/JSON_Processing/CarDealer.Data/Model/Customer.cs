﻿using System;

namespace CarDealer.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
