using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataAppConfig
	   : DependencyCollection
	{
		public GameDataAppConfig(
			IUnityContainer container)
			: base(container)
		{
		}

		public override void RegisterDependencies()
		{
			RegisterDependencyProvider<GameDataAppDatabase>();
			base.RegisterDependencies();
		}

		protected override void RegisterAppData() =>
			RegisterDependencyProvider<GameDataAppData>();

		protected override void RegisterTwoWordMaping() =>
			RegisterDependencyProvider<GameDataAppTwoWordMaping>();

		protected override void RegisterCommandNameSystem() =>
			RegisterDependencyProvider<GameDataAppCommandNameMaping>();

		protected override void RegisterCommands()
		{
			RegisterDependencyProvider<GameDataAppAppCommands>();
			RegisterDependencyProvider<GameDataAppCommands>();
		}
	}
}