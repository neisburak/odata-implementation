using System;

namespace Api.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string Generation { get; set; }
        public int Engine { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
