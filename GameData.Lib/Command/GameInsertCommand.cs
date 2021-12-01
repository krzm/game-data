using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
    public class GameInsertCommand : DataCommand<Game>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;
        private ICommandRunner commandRunner;

		public GameInsertCommand(
			TextCommand command
			, IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
			: base(command)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(textReader);
			
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public void SetCommandRunner(ICommandRunner commandRunner)
		{
			ArgumentNullException.ThrowIfNull(commandRunner);
            this.commandRunner = commandRunner;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Game.Insert(
				new Game
				{
					Name = textReader.Read(new ReadConfig(50, nameof(Game.Name)))
					, Description =textReader.Read(new ReadConfig(250, nameof(Game.Description)))
				});
			unitOfWork.Save();
			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}