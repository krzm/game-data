using System.ComponentModel.DataAnnotations;

namespace GameData.Lib;

public class Strategy
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public string Description { get; set; }
}