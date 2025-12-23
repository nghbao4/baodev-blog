using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baodev.Core.Domain.Content
{
    [Table("Series")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Series
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        public required string Slug { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }

        [MaxLength(256)]
        public string? SeoDescription { get; set; }
        
        [MaxLength(256)]
        public string? Thumnail { get; set; }
        public string? Content { get; set; }
        public Guid AuthorUserId { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
