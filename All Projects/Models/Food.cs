using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models;

public class Food
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NationOfFood { get; set; }
    public List<string> CommentOfFood { get; set; } = new List<string>();
    public double Performance { get; set; }
    public int AmountOfPeopleForEating { get; set; }
    public List<string> NegativComments { get; set; } = new List<string>();
}
