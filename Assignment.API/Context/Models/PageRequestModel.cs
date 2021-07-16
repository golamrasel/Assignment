using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Models
{
    public class PageRequestModel
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public string Keyword { get; set; }
    }
}
