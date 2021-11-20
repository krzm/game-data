using Console.Lib;
using GameData.Lib;
using Unity;
using Unity.Injection;

namespace GameData.ConsoleApp
{
	public class GameDataAppTwoWordMaping
		: TwoWordMaping
	{
		public GameDataAppTwoWordMaping(
			IUnityContainer container)
			: base(container)
		{
		}

		protected override void RegisterTwoWordNames()
		{
			Container
			   .RegisterSingleton<IOneWordNames, OneWordNameFactory>(
				   "Actions"
				   , new InjectionConstructor(
					   new object[] {
							new string[]
							{
								"Help".ToLowerInvariant()
								,"Insert".ToLowerInvariant()
								,"Update".ToLowerInvariant()
							}}));

			Container
				.RegisterSingleton<IOneWordNames, OneWordNameFactory>(
					"Models"
					, new InjectionConstructor(
						new object[] {
							new string[]
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

			Container.RegisterType<ITwoWordNames, TwoWordNameFactory>(
				new InjectionConstructor(
					Container.Resolve<IOneWordNames>("Actions")
					, Container.Resolve<IOneWordNames>("Models")));
		}
	}
}