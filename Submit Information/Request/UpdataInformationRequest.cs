using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class UpdataInformationRequest
    {
        [StringLength(100,ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string? FirstName { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "کد ملی 10 کارکتر عدد باشد")]
        [MinLength(10,ErrorMessage = "کد ملی 10 کارکتر عدد باشد")]
        public string NationalCode { get; set; }
    }
}
