using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class TransferAmountRequest
    {
        [Required]
        [Range(1,int.MaxValue)] 
        public int Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCodeSource { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCodeDestination { get; set; }
    }   
}
