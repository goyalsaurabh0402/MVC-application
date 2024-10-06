using System.ComponentModel.DataAnnotations;

public class Equipment
{
    [Key]
    public int Id { get; set; }
    public string? Type { get; set; }  // Now nullable
    public string? Description { get; set; } // Now nullable
    public bool Available { get; set; }
}

