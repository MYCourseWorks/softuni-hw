﻿using System.Collections.Generic;

namespace CarDealer.Data.Model
{
    public class Car
    {
        public Car()
        {
            this.Parts = new List<Part>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
