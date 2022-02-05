using DIHelper;
using Unity;

namespace GameData.ConsoleApp;

class Program
{
	static void Main(string[] args)
	{
		IBootstraper booter = new Bootstraper(
			new DependencySuite(
				new UnityContainer().AddExtension(new Diagnostic())));
		booter.Boot(args);
	}
}