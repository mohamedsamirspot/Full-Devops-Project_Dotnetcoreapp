using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.ViewModels
{
    public class IndexViewModel
    {
        public IList<News> News { get; set; }
        public IList<Category> Category { get; set; }

    }
}
