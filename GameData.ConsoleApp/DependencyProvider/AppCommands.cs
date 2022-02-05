using System.Collections.Generic;
using CLIFramework;
using CLIHelper;
using CLIReader;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp;

public class AppCommands 
    : CLIFramework.AppCommands
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterCommands()
    {
        base.RegisterCommands();
        RegisterDifficultyCommands();
        RegisterGameCommands();
    }

    private void RegisterDifficultyCommands()
    {
        RegisterCommand<HelpCommand<Difficulty>, Difficulty>(
            "Help Difficulty".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(Difficulty.Name)
                , nameof(Difficulty.Description)
            });

        RegisterCommand<DifficultyReadCommand, Difficulty>(
            "Difficulty".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>());

        RegisterCommand<DifficultyInsertCommand, Difficulty>(
            "Insert Difficulty".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

        RegisterCommand<DifficultyUpdateCommand, Difficulty>(
            "Update Difficulty".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<List<IReader<string>>>());
    }

    private void RegisterGameCommands()
    {
        RegisterCommand<HelpCommand<Game>, Game>(
            "Help Game".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(Game.Name)
                , nameof(Game.Description)
            });

        RegisterCommand<GameReadCommand, Game>(
            "Game".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>());

        RegisterCommand<GameInsertCommand, Game>(
            "Insert Game".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

        RegisterCommand<GameUpdateCommand, Game>(
            "Update Game".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<List<IReader<string>>>());
    }
}