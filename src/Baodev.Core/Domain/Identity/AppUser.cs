using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baodev.Core.Domain.Identity
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(256)]
        public required string FisrtName { get; set; }

        [Required]
        [MaxLength(256)]
        public required string LastName { get; set; }

        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? Dob { get; set; }

        [MaxLength(512)]
        public string? Avatar { get; set; }
        public DateTime? VipStartDate { get; set; }
        public DateTime? VipExprieDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public double Balance { get; set; }

    }
}
