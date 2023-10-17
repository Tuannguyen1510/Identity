using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Course
    {
        [Key]
        public int IdCourses { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Tên Khóa học ")]
        public string CourseName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Mô tả")]
        public string CourseDescription { get; set; }

        public int? IdGroups { get; set; }
        public Group? group { get; set; }
    }
}
