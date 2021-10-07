using System.ComponentModel.DataAnnotations.Schema;

namespace GameData.Lib
{
	public class StrategyStrategyItem
	{
		public int Id { get; set; }

		[ForeignKey("Strategy")]
		public int StrategyId { get; set; }

		[ForeignKey("StrategyItem")]
		public int StrategyItemId { get; set; }

		public Strategy Strategy { get; set; }

		public StrategyItem StrategyItem { get; set; }
	}
}