using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Models
{
    public class Branch: BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Password { get; set; }
        public string Mac { get; set; }
    }
}
