using SeminarHub.Data;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;

namespace SeminarHub.Models
{
    /// <summary>
    /// Seminar view type
    /// </summary>
    public class SeminarViewModel
    {
        /// <summary>
        /// Seminar Topic property
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredTypeErrorMessage)]
        [StringLength(DataConstants.SeminarTopicMaxLenght
            ,MinimumLength =DataConstants.SeminarTopicMinLenght
            ,ErrorMessage = DataConstants.StringLenghtErrorMessage)]
        public string Topic { get; set; } = null!;
        /// <summary>
        /// Seminar Lecturer property
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredTypeErrorMessage)]
        [StringLength(DataConstants.SeminarLecturerMaxLenght
            ,MinimumLength =DataConstants.SeminarLecturerMinLenght
            ,ErrorMessage =DataConstants.StringLenghtErrorMessage)]
        public string Lecturer { get; set; } = null!;
        /// <summary>
        /// Seminar Details property
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredTypeErrorMessage)]
        [StringLength(DataConstants.SeminarDetailsMaxLenght
            ,MinimumLength =DataConstants.SeminarLecturerMinLenght
            ,ErrorMessage =DataConstants.StringLenghtErrorMessage)]
        public string Details { get; set; } = null!;
        /// <summary>
        /// Seminar Date and Time property
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredTypeErrorMessage)]
        public string DateAndTime { get; set; } = null!;
        /// <summary>
        /// Seminar Duration
        /// </summary>
        [Range(DataConstants.SeminarDurationMinValue
            ,DataConstants.SeminarDuratuinMaxValue
            ,ErrorMessage =DataConstants.DurationOutOfRangeError)]
        public int Duration { get; set; }
        /// <summary>
        /// Seminar possible categories
        /// </summary>
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        /// <summary>
        /// Seminar Category identifier
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredTypeErrorMessage)]

        public int CategoryId { get; set; }
    }
}
