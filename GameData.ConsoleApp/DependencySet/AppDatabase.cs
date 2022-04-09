using DIHelper.Unity;
using EFCoreHelper;
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
		var unitOfWork = Container.Resolve<GameDataUnitOfWork>();
		Container.RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
		Container.RegisterInstance<IGameDataUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
	}
}