using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CreateUpdateStudentDto
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public int Roll { get; set; }
        public string Class { get; set; }
    }
}
