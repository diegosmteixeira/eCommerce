using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Office
{
    public class Section
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<EmployeeSection>? EmployeeSection { get; set; }
    }
}