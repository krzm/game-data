using Console.Lib;
using System.Windows.Input;
using Unity;
using Unity.Injection;

namespace GameData.ConsoleApp
{
	public class GameDataAppAppCommands
		: AppCommands
	{
		public GameDataAppAppCommands(
			IUnityContainer container)
			: base(container)
		{
		}

		protected override void RegisterHelpCommand()
		{
			Container
				.RegisterType<ICommand, Lib.HelpCommand>(
					Commands.Command("Help")
					, new InjectionConstructor(
						Container.Resolve<IConsoleIO>()
						, Container.Resolve<IOneWordNames>("AppCommands")
						, Container.Resolve<IOneWordNames>("Actions")
						, Container.Resolve<IOneWordNames>("Models")));
		}
	}
}