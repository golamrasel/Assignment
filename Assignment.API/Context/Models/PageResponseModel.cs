using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Models
{
    public class PageResponseModel<T> where T : class
    {
        public PageResponseModel()
        {
            Rows = new List<T>();
        }
        public List<T> Rows { get; set; }
        public int Count { get; set; }
    }
}
