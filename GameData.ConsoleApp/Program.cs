using Console.Lib;

namespace GameData.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IConsoleBootstraper booter = new GameDataBootstraper();
			booter.Boot(args);
		}
	}
}