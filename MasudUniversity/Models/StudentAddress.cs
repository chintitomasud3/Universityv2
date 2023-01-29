using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasudUniversity.Models
{
    public class StudentAddress
    {
        [Key]
        public int Id { get; set; }
        public string Contact { get; set; }

        public string Address { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
