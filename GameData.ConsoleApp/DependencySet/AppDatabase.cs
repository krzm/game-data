using DIHelper.Unity;
using EFCore.Helper;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp;

public class AppDatabase 
	: UnityDependencySet
{
	public AppDatabase(
		IUnityContainer container)
		: base(container)
	{
	}

	public override void Register()
	{
        Container
            .RegisterSingleton<GameDataContext>()

            .RegisterSingleton<IRepository<Game>, EFRepository<Game, GameDataContext>>()
            .RegisterSingleton<IRepository<Level>, EFRepository<Level, GameDataContext>>()
            .RegisterSingleton<IRepository<Play>, EFRepository<Play, GameDataContext>>()
            .RegisterSingleton<IRepository<PlayStats>, EFRepository<PlayStats, GameDataContext>>()
            .RegisterSingleton<IRepository<Strategy>, EFRepository<Strategy, GameDataContext>>()
            .RegisterSingleton<IRepository<StrategyItem>, EFRepository<StrategyItem, GameDataContext>>()
            .RegisterSingleton<IRepository<StrategyStrategyItem>, EFRepository<StrategyStrategyItem, GameDataContext>>()
            .RegisterSingleton<IRepository<Difficulty>, EFRepository<Difficulty, GameDataContext>>()
            .RegisterSingleton<IRepository<LevelTurn>, EFRepository<LevelTurn, GameDataContext>>()

            .RegisterSingleton<IGameDataUnitOfWork, GameDataUnitOfWork>();
	}
}