using DIHelper;
using GameData.ConsoleApp;
using Unity;

IBootstraper booter = new Bootstraper(
	new UnityDependencySuite(
		new UnityContainer()
			.AddExtension(
				new Diagnostic())));
booter.Boot(args);