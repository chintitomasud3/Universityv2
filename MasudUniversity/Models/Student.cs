using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasudUniversity.Models
{
    public enum Gender
    {
        Male,Female,Other
    }
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }

        public Gender? Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        [Display(Name ="Martial Status")]
        public string MartialStatus { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Blood Group")]
        public string BloodGroup { get; set; }
        public DateTime DOB { get; set; }
        public string Batch { get; set; }

       
        
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<StudentAddress> StudentAddresses { get; set; }


    }
}
