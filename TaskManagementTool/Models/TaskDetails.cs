
using System.ComponentModel.DataAnnotations;
using TaskManagementTool.Converter;
using System.Text.Json.Serialization;

namespace TaskManagementTool.Models;
public class TaskDetails
{
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    [StringLength(499)]
	public required string Description { get; set; }
    [Required(ErrorMessage ="The Category field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? CategoryId { get; set; }
	[Required]
	public required DateOnly DueDate { get; set; }
    public bool IsDone { get; set; }
    public TimeSpan? TimeSpent { get; set; }
}
