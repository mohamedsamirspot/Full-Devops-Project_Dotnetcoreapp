using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public IList<Category> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
