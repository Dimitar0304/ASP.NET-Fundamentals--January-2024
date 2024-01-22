using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TextSpliter.Common;

namespace TextSpliter.Models
{
    /// <summary>
    /// TextViewModel
    /// </summary>
    public class TextViewModel
    {
        [Required(ErrorMessage =UserErrorMessages.Required)]
        [StringLength(30,MinimumLength =2,ErrorMessage =UserErrorMessages.StringLenghtError)]
        public string Text { get; set; } = null!;
        
        public string SplitText { get; set; } = null!;
    }
}
