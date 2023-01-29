using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasudUniversity.Models
{
    public class EmpDepartment
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public string Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
