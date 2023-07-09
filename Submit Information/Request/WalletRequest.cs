using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Request
{
    public class WalletRequest
    {

        [Required(ErrorMessage = "پول ذخیره 10 هزار تومان")]
        [StringLength(10)]
        public decimal Amount { get; set; }

        [Required]
        public bool Block { get; set; }

        [Required(ErrorMessage = "مبلغ بلوکه شده")]
        public decimal AmountBlock { get; set; }

        [Required(ErrorMessage = "شماره حساب را وارد کنید")]
        [StringLength(16)]
        public decimal NumberAccount { get; set; }
    }
}
