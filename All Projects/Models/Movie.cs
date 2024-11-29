using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public Double MovieTime { get; set; }
    public Double AmountOfInvestment { get; set; }
    public List<string> ActorsName { get; set; }
    public List<string> ViewersName { get; set; }

}
