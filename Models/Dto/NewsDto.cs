using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace NewsSite.Models.Dto
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NewsDate { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
