using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class InsertInformationRequest
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }
    }
}
