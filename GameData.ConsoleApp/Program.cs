using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IBootstraper booter = new Bootstraper(
				new DependencyCollection(
					new UnityContainer().AddExtension(new Diagnostic())));
			booter.Boot(args);
		}
	}
}