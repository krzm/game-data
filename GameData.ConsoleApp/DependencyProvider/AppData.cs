using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class AppData : Console.Lib.AppData
	{
		public AppData(
			IUnityContainer container)
			: base(container)
		{
		}

		protected override void SetAppConfigData()
		{
			Config["AppName"] = "Log";
			Config["CommandParser"] = nameof(ParamCommandParser);
		}
	}
}