using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoBackend.Models;

[Table("task")]
public class Task
{
    [Key, Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime LastUpdatedTime { get; set; }

    public DateTime StartedTime { get; set; }

    public DateTime DueTime { get; set; }

    public ICollection<Tag>? Tags { get; set; }

    // default: Backlog
    [EnumDataType(typeof(TaskStage))]
    public TaskStage Stage { get; set; }

    [Range(0, 100)]
    public decimal Progress { get; set; }

    // default: Medium
    [EnumDataType(typeof(TaskPriority))]
    public TaskPriority Priority { get; set; }

    // FIXME: User
    public string? Creator { get; set; }

    // FIXME: User
    public string? Assignee { get; set; }
}

public enum TaskStage { Done, InProgress, Block, Todo, Test, Backlog }

public enum TaskPriority { High, Medium, Low }