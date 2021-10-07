using Console.Lib;
using Core;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataBootstraper : ConsoleBootstraper
	{
		protected override void RegisterDependencyProviders()
		{
			Container.RegisterSingleton<IDependencyProvider<IUnityContainer>, GameDataDependencyProvider>();
		}
	}
}