using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameData.Lib;

public class Play
{
    public int Id { get; set; }

    [ForeignKey("Level")]
    public int LevelId { get; set; }

    [ForeignKey("Difficulty")]
    public int DifficultyId { get; set; }

    [ForeignKey("Strategy")]
    public int StrategyId { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? Start { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? End { get; set; }

    public long? TimeTicks { get; set; }

    [NotMapped]
    public TimeSpan Time
    {
        get { return TimeSpan.FromTicks(TimeTicks ?? default); }
        set { TimeTicks = value.Ticks; }
    }

    [Required]
    [MaxLength(250)]
    public string Description { get; set; }

    public Level Level { get; set; }

    public Difficulty Difficulty { get; set; }

    public Strategy Strategy { get; set; }
}