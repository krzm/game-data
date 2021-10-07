using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameData.Lib
{
	public class LevelTurn
	{
		public int Id { get; set; }

		[ForeignKey("Level")]
		public int LevelId { get; set; }

		[ForeignKey("Difficulty")]
		public int DifficultyId { get; set; }

		[Required]
		public int Turns { get; set; }

		public Level Level { get; set; }

		public Difficulty Difficulty { get; set; }
	}
}