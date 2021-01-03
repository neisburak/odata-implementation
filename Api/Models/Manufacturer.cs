using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
