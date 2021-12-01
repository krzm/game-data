using System.Collections.Generic;
using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp
{
    public class AppCommands4 : AppCommands3
    {
        public AppCommands4(
            IUnityContainer container) 
            : base(container)
        {
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            RegisterStrategyCommands();
            RegisterStrategyItemCommands();
        }

        private void RegisterStrategyCommands()
        {
            RegisterCommand<EntityHelpCommand<Strategy>, Strategy>(
				"Help Strategy".ToLowerInvariant()
				, Container.Resolve<IOutput>()
				, new string[]
				{
					nameof(Strategy.Name)
					, nameof(Strategy.Description)
				});

            RegisterCommand<StrategyReadCommand, Strategy>(
                "Strategy".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IOutput>());

            RegisterCommand<StrategyInsertCommand, Strategy>(
                "Insert Strategy".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

            RegisterCommand<StrategyUpdateCommand, Strategy>(
                "Update Strategy".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<List<IReader<string>>>());
        }

        private void RegisterStrategyItemCommands()
        {
            RegisterCommand<EntityHelpCommand<StrategyItem>, StrategyItem>(
				"Help StrategyItem".ToLowerInvariant()
				, Container.Resolve<IOutput>()
				, new string[]
				{
					nameof(StrategyItem.Name)
					, nameof(StrategyItem.Description)
				});

            RegisterCommand<StrategyItemReadCommand, StrategyItem>(
                "StrategyItem".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IOutput>());

            RegisterCommand<StrategyItemInsertCommand, StrategyItem>(
                "Insert StrategyItem".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));
        }
    }
}