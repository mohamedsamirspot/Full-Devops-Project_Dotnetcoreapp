using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.ViewModels
{
    public class NewsViewModel
    {
        public IList<News> News { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
