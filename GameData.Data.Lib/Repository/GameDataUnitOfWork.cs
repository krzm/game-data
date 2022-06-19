using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace GameData.Lib.Repository;

public class GameDataUnitOfWork 
	: UnitOfWork
        , IGameDataUnitOfWork
{
	private IRepository<Game> game;
	private IRepository<Level> level;
	private IRepository<Play> play;
	private IRepository<PlayStats> playStats;
	private IRepository<Strategy> strategy;
	private IRepository<StrategyItem> strategyItem;
	private IRepository<StrategyStrategyItem> strategyStrategyItem;
	private IRepository<Difficulty> difficulty;
	private IRepository<LevelTurn> levelTurn;

    public IRepository<Game> Game => game;

	public IRepository<Level> Level => level;

	public IRepository<Play> Play => play;

	public IRepository<PlayStats> PlayStats => playStats;

	public IRepository<Strategy> Strategy => strategy;

	public IRepository<StrategyItem> StrategyItem => strategyItem;

	public IRepository<StrategyStrategyItem> StrategyStrategyItem => strategyStrategyItem;

	public IRepository<Difficulty> Difficulty => difficulty;

	public IRepository<LevelTurn> LevelTurn => levelTurn;

     public GameDataUnitOfWork(
        DbContext context
        , IRepository<Game> game
        , IRepository<Level> level
        , IRepository<Play> play
        , IRepository<PlayStats> playStats
        , IRepository<Strategy> strategy
        , IRepository<StrategyItem> strategyItem
        , IRepository<StrategyStrategyItem> strategyStrategyItem
        , IRepository<Difficulty> difficulty
        , IRepository<LevelTurn> levelTurn)
            : base(context)
    {
        this.game = game;
        this.level = level;
        this.play = play;
        this.playStats = playStats;
        this.strategy = strategy;
        this.strategyItem = strategyItem;
        this.strategyStrategyItem = strategyStrategyItem;
        this.difficulty = difficulty;
        this.levelTurn = levelTurn;
    }
}