using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models;

public class Dish
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Double Price { get; set; }
    public string Description { get; set; }
    public Guid RestaurantId { get; set; }
}
