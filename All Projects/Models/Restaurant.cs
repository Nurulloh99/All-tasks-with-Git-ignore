using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models
{
    public class Restaurant
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime Opened_Date { get; set; } = DateTime.Now;
        public string Nation_of_restaurant { get; set; }

    }
}
