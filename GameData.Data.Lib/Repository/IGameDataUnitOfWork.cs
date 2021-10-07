using Core;
using Core.Lib;

namespace GameData.Lib.Repository
{
	public interface IGameDataUnitOfWork : IUnitOfWork
	{
		EFGenericRepository<Difficulty, GameDataContext> Difficulty { get; }
		EFGenericRepository<Game, GameDataContext> Game { get; }
		EFGenericRepository<Level, GameDataContext> Level { get; }
		EFGenericRepository<Play, GameDataContext> Play { get; }
		EFGenericRepository<PlayStats, GameDataContext> PlayStats { get; }
		EFGenericRepository<Strategy, GameDataContext> Strategy { get; }
		EFGenericRepository<StrategyItem, GameDataContext> StrategyItem { get; }
		EFGenericRepository<StrategyStrategyItem, GameDataContext> StrategyStrategyItem { get; }
		EFGenericRepository<LevelTurn, GameDataContext> LevelTurn { get; }
	}
}