using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyStrategyItemInsertCommand : DataCommand<StrategyStrategyItem>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;
        private ICommandRunner commandRunner;

		public StrategyStrategyItemInsertCommand(
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
			unitOfWork.StrategyStrategyItem.Insert(
				new StrategyStrategyItem
				{
					StrategyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(StrategyStrategyItem.StrategyId))))
					, StrategyItemId = int.Parse(textReader.Read(new ReadConfig(6, nameof(StrategyStrategyItem.StrategyItemId))))
				});
			unitOfWork.Save();
			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}