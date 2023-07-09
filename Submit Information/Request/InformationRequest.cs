using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class InformationRequest
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [StringLength(10)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Key]
        [Required(ErrorMessage = "کد ملی را وارد کنید")]
        [StringLength(10)]
        public string NationalCode { get; set; }
    }
}
