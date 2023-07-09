using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class UpdateWalletRequest
    {
        [StringLength(10, ErrorMessage = "پول ذخیره 10 هزار تومان می باشد")]
        [MinLength(10, ErrorMessage = "پول ذخیره 10 هزار تومان می باشد")]
        public decimal Amount { get; set; }

        [Required]
        public bool Block { get; set; }
        [Key]
        [Required]
        public decimal AmountBlock { get; set; }

        [StringLength(16, ErrorMessage = "شماره حساب 16 کارکتر عدد می باشد")]
        [MinLength(16, ErrorMessage = "شماره حساب 16 کارکتر عدد می باشد")]
        public decimal NumberAccount { get; set; }
    }
}
