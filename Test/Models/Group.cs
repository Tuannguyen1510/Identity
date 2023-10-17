using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Group
    {
        [Key]
        public int IdGroups { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Tên Nhóm Khóa học ")]
        public string GroupName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Mô tả")]
        public string GroupDescription { get; set; }

        public List<Course>? courses  { get; set; }
    }
}
