
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Models
{
    public class TaskFormModel 
    {
        [Required]
        [StringLength(Data.DataConstants.TaskConstants.TaskTitleMaxLenght
            ,MinimumLength=Data.DataConstants.TaskConstants.TaskTitleMinLenght
            ,ErrorMessage ="Title should be at least {2} characters long")
            ]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(Data.DataConstants.TaskConstants.TaskDescriptionMaxLenght
            , MinimumLength = Data.DataConstants.TaskConstants.TaskDescriptionMinLenght
            , ErrorMessage = "Description should be at least {2} characters long")
            ]
        public string Description { get; set; } = null!;
        [Display(Name ="BoardId")]
        public int BoardId { get; set; }
        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();

    }
}
