using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Models;

public class Book
{

    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Description { get; set; }
    public int PageNumber { get; set; }
    public Double Price { get; set; }
    public List<string> AuthorsName { get; set; }
    public List<string> ReaderName { get; set; }

}
