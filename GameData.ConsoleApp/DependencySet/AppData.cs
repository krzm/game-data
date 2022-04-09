using CLIFramework;
using Unity;

namespace GameData.ConsoleApp;

public class AppData 
	: CLIFramework.AppData
{
	public AppData(
		IUnityContainer container)
		: base(container)
	{
	}

	protected override void SetAppConfigData()
	{
		Config["AppName"] = "Game";
		Config["CommandParser"] = nameof(ParamCommandParser);
	}
}