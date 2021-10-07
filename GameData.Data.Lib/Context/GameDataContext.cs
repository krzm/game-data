using Microsoft.EntityFrameworkCore;

namespace GameData.Lib
{
	public class GameDataContext : DbContext
	{
		public DbSet<Game> Games { get; set; }

		public DbSet<Level> Levels { get; set; }

		public DbSet<LevelTurn> LevelTurns { get; set; }

		public DbSet<Play> Plays { get; set; }

		public DbSet<PlayStats> PlayStats { get; set; }

		public DbSet<Strategy> Strategies { get; set; }

		public DbSet<StrategyItem> StrategyItems { get; set; }

		public DbSet<StrategyStrategyItem> StrategyStrategyItems { get; set; }

		public DbSet<Difficulty> Difficulties { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GameData");
		}
	}
}