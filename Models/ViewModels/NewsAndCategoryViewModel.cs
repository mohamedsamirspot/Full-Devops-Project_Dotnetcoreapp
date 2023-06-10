using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.ViewModels
{
    public class NewsAndCategoryViewModel
    {

        public IEnumerable<Category> CategoryList { get; set; }
        public News News { get; set; }
        public string StatusMessage { get; set; }

    }
}
