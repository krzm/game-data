using Core;
using Core.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp
{
	public class AppDatabase : UnityDependencyProvider
	{
		public AppDatabase(
			IUnityContainer container)
			: base(container)
		{
		}

		public override void RegisterDependencies()
		{
			var unitOfWork = Container.Resolve<GameDataUnitOfWork>();
			Container.RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
			Container.RegisterInstance<IGameDataUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
		}
	}
}