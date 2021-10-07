using System;
using Core.Lib;

namespace GameData.Lib.Repository
{
	public class GameDataUnitOfWork : IGameDataUnitOfWork
	{
		private readonly GameDataContext context = new();
		private EFGenericRepository<Game, GameDataContext> game;
		private EFGenericRepository<Level, GameDataContext> level;
		private EFGenericRepository<Play, GameDataContext> play;
		private EFGenericRepository<Strategy, GameDataContext> strategy;
		private EFGenericRepository<StrategyItem, GameDataContext> strategyItem;
		private EFGenericRepository<StrategyStrategyItem, GameDataContext> strategyStrategyItem;
		private EFGenericRepository<Difficulty, GameDataContext> difficulty;
		private EFGenericRepository<LevelTurn, GameDataContext> levelTurn;
		private EFGenericRepository<PlayStats, GameDataContext> playStats;

		private bool disposed = false;

		public EFGenericRepository<Game, GameDataContext> Game
		{
			get
			{

				if (game == null)
				{
					game = new EFGenericRepository<Game, GameDataContext>(context);
				}
				return game;
			}
		}

		public EFGenericRepository<Level, GameDataContext> Level
		{
			get
			{

				if (level == null)
				{
					level = new EFGenericRepository<Level, GameDataContext>(context);
				}
				return level;
			}
		}

		public EFGenericRepository<Play, GameDataContext> Play
		{
			get
			{

				if (play == null)
				{
					play = new EFGenericRepository<Play, GameDataContext>(context);
				}
				return play;
			}
		}

		public EFGenericRepository<PlayStats, GameDataContext> PlayStats
		{
			get
			{

				if (playStats == null)
				{
					playStats = new EFGenericRepository<PlayStats, GameDataContext>(context);
				}
				return playStats;
			}
		}

		public EFGenericRepository<Strategy, GameDataContext> Strategy
		{
			get
			{

				if (strategy == null)
				{
					strategy = new EFGenericRepository<Strategy, GameDataContext>(context);
				}
				return strategy;
			}
		}

		public EFGenericRepository<StrategyItem, GameDataContext> StrategyItem
		{
			get
			{

				if (strategyItem == null)
				{
					strategyItem = new EFGenericRepository<StrategyItem, GameDataContext>(context);
				}
				return strategyItem;
			}
		}

		public EFGenericRepository<StrategyStrategyItem, GameDataContext> StrategyStrategyItem
		{
			get
			{

				if (strategyStrategyItem == null)
				{
					strategyStrategyItem = new EFGenericRepository<StrategyStrategyItem, GameDataContext>(context);
				}
				return strategyStrategyItem;
			}
		}

		public EFGenericRepository<Difficulty, GameDataContext> Difficulty
		{
			get
			{

				if (difficulty == null)
				{
					difficulty = new EFGenericRepository<Difficulty, GameDataContext>(context);
				}
				return difficulty;
			}
		}

		public EFGenericRepository<LevelTurn, GameDataContext> LevelTurn
		{
			get
			{

				if (levelTurn == null)
				{
					levelTurn = new EFGenericRepository<LevelTurn, GameDataContext>(context);
				}
				return levelTurn;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}