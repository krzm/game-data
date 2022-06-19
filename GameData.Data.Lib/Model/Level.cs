using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameData.Lib;

public class Level
{
    public int Id { get; set; }

    [ForeignKey("Game")]
    public int GameId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public string Objective { get; set; }

    public Game Game { get; set; }
}