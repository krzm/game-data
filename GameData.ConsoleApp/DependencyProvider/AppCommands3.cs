using System;
using System.Collections.Generic;
using CLIFramework;
using CLIHelper;
using CLIReader;
using GameData.Lib;
using GameData.Lib.Repository;
using Unity;

namespace GameData.ConsoleApp;

public class AppCommands3 
    : AppCommands2
{
    public AppCommands3(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterCommands()
    {
        base.RegisterCommands();
        RegisterPlayCommands();
        RegisterPlayStatsCommands();
    }

    private void RegisterPlayCommands()
    {
        RegisterCommand<HelpCommand<Play>, Play>(
            "Help Play".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(Play.LevelId)
                , nameof(Play.DifficultyId)
                , nameof(Play.StrategyId)
                , nameof(Play.Start)
                , nameof(Play.End)
                , nameof(Play.TimeTicks)
                , nameof(Play.Description)
                , nameof(Play.DifficultyId)
                , nameof(Play.DifficultyId)
            });

        RegisterCommand<PlayReadCommand, Play>(
            "Play".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>());

        RegisterCommand<PlayInsertCommand, Play>(
            "Insert Play".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));

        RegisterCommand<PlayUpdateCommand, Play>(
            "Update Play".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>()
            , Container.Resolve<List<IReader<string>>>()
            , Container.Resolve<List<IReader<DateTime?>>>());
    }

    private void RegisterPlayStatsCommands()
    {
        RegisterCommand<HelpCommand<PlayStats>, PlayStats>(
            "Help PlayStats".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(PlayStats.PlayId)
                , nameof(PlayStats.Win)
                , nameof(PlayStats.TurnsPlayed)
                , nameof(PlayStats.Resources)
                , nameof(PlayStats.UnitsLost)
                , nameof(PlayStats.UnitsLevelUps)
            });

        RegisterCommand<PlayStatsReadCommand, PlayStats>(
            "PlayStats".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>());

        RegisterCommand<PlayStatsInsertCommand, PlayStats>(
            "Insert PlayStats".ToLowerInvariant()
            , Container.Resolve<IGameDataUnitOfWork>()
            , Container.Resolve<IOutput>()
            , Container.Resolve<IInput>()
            , Container.Resolve<IReader<string>>(nameof(RequiredTextReader)));
    }
}