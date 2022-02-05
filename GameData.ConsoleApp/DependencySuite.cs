using CLIFramework;
using Unity;

namespace GameData.ConsoleApp;

public class DependencySuite 
	: DIHelper.Unity.UnityDependencySuite
{
	public DependencySuite(
		IUnityContainer container)
		: base(container)
	{
	}

	public override void Register()
	{
		RegisterSet<AppDatabase>();
		base.Register();
	}

	protected override void RegisterAppData() => 
		RegisterSet<AppData>();

	protected override void RegisterCommands() => 
		RegisterSet<AppCommands5>();
	
	protected override void RegisterCommandSystem() => 
		RegisterSet<AppCommandSystem<ParamCommandParser>>();
}