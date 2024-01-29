using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Models
{
    [Comment("Post entity")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Comment("Post Title")]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(1500)]
        [Comment("Post content")]
        public string Content { get; set; }=null!;
    }
}
