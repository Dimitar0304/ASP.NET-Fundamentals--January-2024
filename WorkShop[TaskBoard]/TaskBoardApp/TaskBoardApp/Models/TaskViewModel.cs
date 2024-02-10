using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models
{/// <summary>
/// Task view model
/// </summary>
    public class TaskViewModel
    {
        /// <summary>
        /// Task view model Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Task view model Title
        /// </summary>
        [Required]
        [MaxLength(DataConstants.TaskConstants.TaskTitleMaxLenght)]
        [MinLength(DataConstants.TaskConstants.TaskTitleMinLenght)]
        public string Title { get; set; } = null!;
        /// <summary>
        /// Task view model Description
        /// </summary>
        [Required]
        [MaxLength(DataConstants.TaskConstants.TaskDescriptionMaxLenght)]
        [MinLength(DataConstants.TaskConstants.TaskDescriptionMinLenght)]
        public string Description { get; set; } = null!;
       
        /// <summary>
        /// Task view model owner Identifier
        /// </summary>
        public string Owner { get; set; } = null!;
    }
}
