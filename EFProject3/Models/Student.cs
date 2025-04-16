using System.ComponentModel.DataAnnotations;

namespace EFProject3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Class { get; set; }
        public string Email { get; set; }
    }

}
