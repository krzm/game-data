using Console.Lib;
using Unity;

namespace GameData.ConsoleApp
{
	public class GameDataAppCommandNameMaping
		: CommandNameMaping
	{
		public GameDataAppCommandNameMaping(
			IUnityContainer container)
			: base(container)
		{
		}

		protected override void AddCommandNames()
		{
			base.AddCommandNames();
			AddNames(Container.Resolve<IOneWordNames>("Models").GetInstance());
			AddNames(Container.Resolve<ITwoWordNames>().GetInstance());
		}
	}
}