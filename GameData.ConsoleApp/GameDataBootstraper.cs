using Console.Lib;
using Core.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataBootstraper : ConsoleBootstraper
	{
		protected override void RegisterDependencyCollection()
		{
			Container.RegisterSingleton<IUnityDependencyCollection, GameDataAppConfig>("DefaultConfig");
		}
	}
}