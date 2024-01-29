using ForumApp.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Models
{
    [Comment("Post View Model")]
    public class PostViewModel
    {
        [Key]
        [Display(Name ="Post Identifier")]
        public int Id { get; set; }
        [Required(ErrorMessage =UserPostErrorMessages.RequiredString)]
        [Display(Name ="Title")]
        [StringLength(PostValidationConstants.TitleMaxLenght,MinimumLength =PostValidationConstants.TitleMinLenght,ErrorMessage =UserPostErrorMessages.LenghtError)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage =UserPostErrorMessages.RequiredString)]
        [Display(Name ="Content")]
        [StringLength(PostValidationConstants.ContentMaxLenght,MinimumLength =PostValidationConstants.ContentMinLenght,ErrorMessage =UserPostErrorMessages.LenghtError)]
        public string Content { get; set; } = null!;
    }
}
