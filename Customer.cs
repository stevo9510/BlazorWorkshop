using System.ComponentModel.DataAnnotations;

namespace BlazorWorkshop
{
    public class Customer
    {
        public int CustomerId { get; set; }
     
        [Required]
        [StringLength(50, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Email is too long")]
        public string Email { get; set; }
    }
}
