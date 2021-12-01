using System.Collections.Generic;
using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp
{
    public class AppCommands2 : AppCommands
    {
        public AppCommands2(
            IUnityContainer container) 
            : base(container)
        {
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            RegisterLevelCommands();
            RegisterLevelTurnCommands();
        }

        private void RegisterLevelCommands()
        {
            RegisterCommand<EntityHelpCommand<Level>, Level>(
				"Help Level".ToLowerInvariant()
				, Container.Resolve<IOutput>()
				, new string[]
				{
					nameof(Level.GameId)
                    , nameof(Level.Name)
					, nameof(Level.Objective)
				});

            RegisterCommand<LevelReadCommand, Level>(
                "Level".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IOutput>());

            RegisterCommand<LevelInsertCommand, Level>(
                "Insert Level".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

            RegisterCommand<LevelUpdateCommand, Level>(
                "Update Level".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<List<IReader<string>>>());
        }
    
        private void RegisterLevelTurnCommands()
        {
            RegisterCommand<EntityHelpCommand<LevelTurn>, LevelTurn>(
				"Help LevelTurn".ToLowerInvariant()
				, Container.Resolve<IOutput>()
				, new string[]
				{
					nameof(LevelTurn.LevelId)
					, nameof(LevelTurn.DifficultyId)
					, nameof(LevelTurn.Turns)
				});

            RegisterCommand<LevelTurnReadCommand, LevelTurn>(
                "LevelTurn".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IOutput>());

            RegisterCommand<LevelTurnInsertCommand, LevelTurn>(
                "Insert LevelTurn".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

            RegisterCommand<LevelTurnUpdateCommand, LevelTurn>(
                "Update LevelTurn".ToLowerInvariant()
                , Container.Resolve<IGameDataUnitOfWork>()
                , Container.Resolve<List<IReader<string>>>());
        }
    }
}