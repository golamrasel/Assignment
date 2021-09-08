using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CreateUpdateLocationDto
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public double Rate { get; set; }
        public int BranchId { get; set; }
    }
}
