using System.ComponentModel.DataAnnotations.Schema;

namespace GameData.Lib
{
	public class PlayStats
	{
		public int Id { get; set; }

		[ForeignKey("Play")]
		public int PlayId { get; set; }

		public bool Win { get; set; }

		public int TurnsPlayed { get; set; }

		public int Resources { get; set; }

		public int UnitsLost { get; set; }

		public int UnitsLevelUps { get; set; }

		public Play Play { get; set; }
	}
}