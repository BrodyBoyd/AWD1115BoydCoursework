using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "PLease enter a description!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PLease enter a due date!")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "PLease select a category!")]
        public string CategoryId { get; set; } = string.Empty;

        [ValidateNever]
        public Category Category { get; set; } = null!;

        [Required(ErrorMessage = "PLease select a status!")]
        public string StatusId { get; set; } = string.Empty;

        [ValidateNever]
        public Status Status { get; set; }

        public bool Overdue => StatusId == "open" && DueDate < DateTime.Today;

    }
}
