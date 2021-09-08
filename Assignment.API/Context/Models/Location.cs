using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Models
{
    public class Location : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public double Rate { get; set; }
        public int BranchId { get; set; }
    }
}
