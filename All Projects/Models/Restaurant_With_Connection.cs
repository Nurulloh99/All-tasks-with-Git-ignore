using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models;

public class Restaurant_With_Connection
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int Rating { get; set; }
    public Guid DishId { get; set; }
}
