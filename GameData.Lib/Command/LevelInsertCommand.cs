using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelInsertCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;
        private ICommandRunner commandRunner;

		public LevelInsertCommand(
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
			unitOfWork.Level.Insert(
				new Level
				{
					GameId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Level.GameId))))
					, Name = textReader.Read(new ReadConfig(50, nameof(Level.Name)))
					, Objective = textReader.Read(new ReadConfig(250, nameof(Level.Objective)))
				});
			unitOfWork.Save();
			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}