using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrudTaskAPi.Resource.Requests
{
    public class EmployeeRequest
    {
        
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string DateOfJoining { get; set; }

    }
}
