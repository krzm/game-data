using Console.Lib;
using GameData.Lib;
using Unity;

namespace GameData.ConsoleApp
{
    public class CommandSystem<TParser> : Console.Lib.CommandSystem<TParser>
        where TParser : ICommandParser
    {
        public CommandSystem(
            IUnityContainer container) 
            : base(container)
        {
        }

        protected override void SetCommandDependencies()
        {
            var commandRunner = Container.Resolve<ICommandRunner>();

            (Container.Resolve<IAppCommand>("insert difficulty") as DifficultyInsertCommand).SetCommandRunner(commandRunner);
            (Container.Resolve<IAppCommand>("update difficulty") as DifficultyUpdateCommand).SetCommandRunner(commandRunner);

            (Container.Resolve<IAppCommand>("insert game") as GameInsertCommand).SetCommandRunner(commandRunner);
            (Container.Resolve<IAppCommand>("update game") as GameUpdateCommand).SetCommandRunner(commandRunner);

            (Container.Resolve<IAppCommand>("insert level") as LevelInsertCommand).SetCommandRunner(commandRunner);
            (Container.Resolve<IAppCommand>("update level") as LevelUpdateCommand).SetCommandRunner(commandRunner);
        }
    }
}