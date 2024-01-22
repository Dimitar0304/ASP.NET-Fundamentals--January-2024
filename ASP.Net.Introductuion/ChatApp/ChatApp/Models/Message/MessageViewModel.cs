using ChatApp.Common;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models.Message
{
    /// <summary>
    /// MessageViewModel
    /// </summary>
    public class MessageViewModel
    {
        /// <summary>
        /// Автор на съобщението
        /// </summary>
        [Required(ErrorMessage =UserErrorMessages.Required)]
        [StringLength(100,MinimumLength =3,ErrorMessage =UserErrorMessages.StringLenghtError)]
        [Display(Name ="Автор на съобщението")]
        public string Sender { get; set; } = null!;
        /// <summary>
        /// Съобщение
        /// </summary>
        [Required(ErrorMessage =UserErrorMessages.Required)]
        [StringLength (1500,MinimumLength =1,ErrorMessage =UserErrorMessages.StringLenghtError)]
        [Display(Name ="Съобщение")]
        public string Message { get; set; } = null!;
    }
}
