using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Data.ViewModels
{
    public class UserVM
    {

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
