using Core;
using GameData.Lib;
using System.Windows.Input;
using Unity;
using Unity.Injection;
using GameData.Lib.Repository;
using Console.Lib;

namespace GameData.ConsoleApp
{
	public class GameDataDependencyProvider : ConsoleAppDependencyProvider
	{
		public override string AppName => "GameData";

		public GameDataDependencyProvider(
			IUnityContainer unityContainer) :
				base(unityContainer)
		{
		}

		protected override void RegisterUnitOfWork()
		{
			Container.RegisterType<IGameDataUnitOfWork, GameDataUnitOfWork>();
		}

		protected override void RegisterCommandNameFactories()
		{
			Container
				.RegisterType<IFactory<string[]>, OneWordNameFactory>(
					"one word"
					, new InjectionConstructor(new object[] {
						new string[]
						{
							"help".ToLowerInvariant()
							, "exit".ToLowerInvariant()
						}}));
			Container
				.RegisterType<IFactory<string[]>, DataCommandNameFactory>(
					new InjectionConstructor(new object[] {
						new string[]
						{
							""
							,"insert"
							,"update"
						}
						, new string[]
						{
							nameof(Difficulty).ToLowerInvariant()
							, nameof(Game).ToLowerInvariant()
							, nameof(Level).ToLowerInvariant()
							, nameof(LevelTurn).ToLowerInvariant()
							, nameof(Play).ToLowerInvariant()
							, nameof(PlayStats).ToLowerInvariant()
							, nameof(Strategy).ToLowerInvariant()
							, nameof(StrategyItem).ToLowerInvariant()
							, nameof(StrategyStrategyItem).ToLowerInvariant()
						}}));
		}

		protected override void RegisterCommands()
		{
			base.RegisterCommands();
			Container
				.RegisterType<ICommand, GameReadCommand>(Commands.Read(nameof(Game)))
				.RegisterType<ICommand, GameInsertCommand>(Commands.Insert(nameof(Game)))
				.RegisterType<ICommand, GameUpdateCommand>(Commands.Update(nameof(Game)))
				.RegisterType<ICommand, DifficultyReadCommand>(Commands.Read(nameof(Difficulty)))
				.RegisterType<ICommand, DifficultyInsertCommand>(Commands.Insert(nameof(Difficulty)))
				.RegisterType<ICommand, DifficultyUpdateCommand>(Commands.Update(nameof(Difficulty)))
				.RegisterType<ICommand, LevelReadCommand>(Commands.Read(nameof(Level)))
				.RegisterType<ICommand, LevelInsertCommand>(Commands.Insert(nameof(Level)))
				.RegisterType<ICommand, LevelUpdateCommand>(Commands.Update(nameof(Level)))
				.RegisterType<ICommand, PlayReadCommand>(Commands.Read(nameof(Play)))
				.RegisterType<ICommand, PlayInsertCommand>(Commands.Insert(nameof(Play)))
				.RegisterType<ICommand, PlayUpdateCommand>(Commands.Update(nameof(Play)))
				.RegisterType<ICommand, PlayStatsReadCommand>(Commands.Read(nameof(PlayStats)))
				.RegisterType<ICommand, PlayStatsInsertCommand>(Commands.Insert(nameof(PlayStats)))
				.RegisterType<ICommand, StrategyReadCommand>(Commands.Read(nameof(Strategy)))
				.RegisterType<ICommand, StrategyInsertCommand>(Commands.Insert(nameof(Strategy)))
				.RegisterType<ICommand, StrategyUpdateCommand>(Commands.Update(nameof(Strategy)))
				.RegisterType<ICommand, StrategyItemInsertCommand>(Commands.Insert(nameof(StrategyItem)))
				.RegisterType<ICommand, StrategyItemReadCommand>(Commands.Read(nameof(StrategyItem)))
				.RegisterType<ICommand, StrategyStrategyItemInsertCommand>(Commands.Insert(nameof(StrategyStrategyItem)))
				.RegisterType<ICommand, LevelTurnReadCommand>(Commands.Read(nameof(LevelTurn)))
				.RegisterType<ICommand, LevelTurnInsertCommand>(Commands.Insert(nameof(LevelTurn)))
				.RegisterType<ICommand, LevelTurnUpdateCommand>(Commands.Update(nameof(LevelTurn)));
		}

		protected override void RegisterProgram()
		{
			RegisterProgram<GameDataProgram>(nameof(CommandParser));
		}
	}
}