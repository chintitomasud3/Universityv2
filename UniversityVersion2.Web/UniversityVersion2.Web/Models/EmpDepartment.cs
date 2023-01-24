using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityVersion2.Web.Models
{
    public class EmpDepartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}