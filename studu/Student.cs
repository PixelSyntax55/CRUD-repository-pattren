using System.ComponentModel.DataAnnotations;
namespace lastoneapi.studu
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0,100)]
        public int Age { get; set; }


        [Required]
        [Range(1,8)]
        public int Semester { get; set; }







    }
}
