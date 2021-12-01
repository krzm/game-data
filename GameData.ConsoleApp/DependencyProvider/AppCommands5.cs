using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp
{
    public class AppCommands5 : AppCommands4
    {
        public AppCommands5(
            IUnityContainer container) 
            : base(container)
        {
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            RegisterStrategyStrategyItemCommands();
        }

        private void RegisterStrategyStrategyItemCommands()
        {
            RegisterCommand<EntityHelpCommand<StrategyStrategyItem>, StrategyStrategyItem>(
				"Help StrategyStrategyItem".ToLowerInvariant()
				, Container.Resolve<IOutput>()
				, new string[]
				{
					nameof(StrategyStrategyItem.StrategyId)
					, nameof(StrategyStrategyItem.StrategyItemId)
				});

            RegisterCommand<StrategyStrategyItemInsertCommand, StrategyStrategyItem>(
                "Insert StrategyStrategyItem".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));
        }
    }
}