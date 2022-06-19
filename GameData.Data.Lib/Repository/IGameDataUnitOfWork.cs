using EFCore.Helper;

namespace GameData.Lib.Repository;

public interface IGameDataUnitOfWork 
    : IUnitOfWork
{
	IRepository<Game> Game { get; }
	IRepository<Level> Level { get; }
	IRepository<Play> Play { get; }
	IRepository<PlayStats> PlayStats { get; }
	IRepository<Strategy> Strategy { get; }
	IRepository<StrategyItem> StrategyItem { get; }
	IRepository<StrategyStrategyItem> StrategyStrategyItem { get; }
	IRepository<Difficulty> Difficulty { get; }
	IRepository<LevelTurn> LevelTurn { get; }
}