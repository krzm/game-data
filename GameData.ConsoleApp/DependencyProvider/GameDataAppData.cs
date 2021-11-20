using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataAppData
		: AppData
	{
		public GameDataAppData(
			IUnityContainer container)
			: base(container)
		{
		}

		public override void RegisterDependencies()
		{
			base.RegisterDependencies();

			Container.RegisterSingleton<IOneWordNames, OneWordCommandNames>("OneWordCommands");
		}

		protected override void SetAppConfigData()
		{
			Config["AppName"] = "Log";
			Config["OneWordCommands"] = "OneWordCommands";
			Config["CommandParser"] = nameof(ParamCommandParser);
		}
	}
}