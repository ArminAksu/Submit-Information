using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Submit_Information.Entity
{
    public class Wallet
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool Block { get; set; }
      
        [Required]
        public decimal AmountBlock { get; set; }
        
        [Required]
        [StringLength (16)]
        public decimal NumberAccount { get; set; }

        [Required]
        public int InformationId { get; set; }


        [ForeignKey("InformationId")]
        public virtual Information Information { get; set; }
    }
}
