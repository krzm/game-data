using Console.Lib;
using Core;
using System.Windows.Input;

namespace GameData.ConsoleApp
{
	public class GameDataProgram : ConsoleAppProgram
	{
		public GameDataProgram(
			IAppData appInfo
			, ICommandParser commandParser
			, IFactory<string, ICommand> commandsFactory
			, ISwitcher switcher
			, IConsoleIO consoleIO) : base(appInfo, commandParser, commandsFactory, switcher, consoleIO)
		{
		}
	}
}