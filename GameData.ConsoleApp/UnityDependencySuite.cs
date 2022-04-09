using CLIFramework;
using CLIHelper.Unity;
using CLIReader;
using Config.Wrapper.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace GameData.ConsoleApp;

public class UnityDependencySuite 
	: CLIFramework.UnityDependencySuite
{
	public UnityDependencySuite(
		IUnityContainer container)
		: base(container)
	{
	}

	protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
		RegisterSet<AppData>();
        Container.RegisterSingleton<ISwitcher, Switcher>("LoopSwitch");
    }

	protected override void RegisterDatabase() => 
        RegisterSet<AppDatabase>();
	
	protected override void RegisterConsoleInput()
    {
        RegisterSet<CliIOSet>();
        RegisterSet<CLIReaderSet>();
    }
	
	protected override void RegisterCommands() => 
		RegisterSet<AppCommands5>();
	
	protected override void RegisterCommandSystem() => 
		RegisterSet<AppCommandSystem<ParamCommandParser>>();
}