using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TodoBackend.Models;

[Table("tag")]
public class Tag
{
    [Key, Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public DateTime CreatedTime { get; set; }

    [JsonIgnore]
    public DateTime LastUpdatedTime { get; set; }

    [JsonIgnore]
    public ICollection<Task>? Tasks { get; set; }
}

