using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace lastoneapi.School.Controllers.DTOS
{
    public class ResponceStudentDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public int Semester { get; set; }
     
    }
}