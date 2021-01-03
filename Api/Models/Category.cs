using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Category
    {
        public Category()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
