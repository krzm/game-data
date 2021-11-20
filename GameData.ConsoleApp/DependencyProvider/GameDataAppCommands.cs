using Console.Lib;
using Core.Lib;
using GameData.Lib;
using System.Windows.Input;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataAppCommands
		: UnityDependencyProvider
	{
		public GameDataAppCommands(
			IUnityContainer container)
			: base(container)
		{
		}

		public override void RegisterDependencies()
		{
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
	}
}