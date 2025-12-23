using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baodev.Core.Domain.Content
{
    [Table("PostCategories")]
    [Index(nameof(Slug), IsUnique = true)]
    public class PostCategory
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(256)]
        public required string Name { get; set; }

        [Column(TypeName = "varchar(256)")]
        public required string Slug { get; set; }

        public Guid? ParentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        [MaxLength(512)]
        public string? SeoDescription { get; set; }
        public int SortOrder { get; set; }
    }
}
