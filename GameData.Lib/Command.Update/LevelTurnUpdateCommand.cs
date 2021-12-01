using System;
using System.Collections.Generic;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnUpdateCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
        private readonly IReader<string> requiredTextReader;
        private ICommandRunner commandRunner;

		public LevelTurnUpdateCommand(
			TextCommand textCommand
			, IGameDataUnitOfWork unitOfWork
			, List<IReader<string>> textReaders)
			: base(textCommand)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(textReaders);

			this.unitOfWork = unitOfWork;
            requiredTextReader = textReaders[0];
		}

		public void SetCommandRunner(ICommandRunner commandRunner)
		{
			ArgumentNullException.ThrowIfNull(commandRunner);
            this.commandRunner = commandRunner;
		}
		
		public override void Execute(object parameter)
		{
			var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TextCommand.TypeName} Id.")));

			var model = unitOfWork.LevelTurn.GetByID(id);

            const string p1 = nameof(LevelTurn.Turns);

            var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{p1}.")));

			if (nr == 1)
				model.Turns = int.Parse(requiredTextReader.Read(new ReadConfig(6, p1)));
			
			unitOfWork.Save();
			
			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}