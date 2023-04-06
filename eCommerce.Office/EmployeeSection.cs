using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class EmployeeSection
    {
        public int EmployeeId { get; set; }
        public int SectionId { get; set; }
        public DateTimeOffset Created { get; set; }
        public Employee? Employee { get; set; }
        public Section? Section { get; set; }
        
    }
}