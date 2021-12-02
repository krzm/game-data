using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class DependencyCollection : Console.Lib.DependencyCollection
	{
		public DependencyCollection(
			IUnityContainer container)
			: base(container)
		{
		}

		public override void RegisterDependencies()
        {
            RegisterDependencyProvider<AppDatabase>();
            base.RegisterDependencies();
        }

        protected override void RegisterAppData() => 
			RegisterDependencyProvider<AppData>();

        protected override void RegisterCommands() => 
            RegisterDependencyProvider<AppCommands5>();
        
        protected override void RegisterCommandSystem() => 
			RegisterDependencyProvider<AppCommandSystem<ParamCommandParser>>();
	}
}