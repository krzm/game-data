using System.Collections.Generic;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnUpdateCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly ICommandRunner commandRunner;
        private readonly IReader<string> requiredTextReader;

		public LevelTurnUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, ICommandRunner commandRunner
			, List<IReader<string>> textReader)
		{
			this.unitOfWork = unitOfWork;
            this.commandRunner = commandRunner;
            requiredTextReader = textReader[0];
		}

		public override void Execute(object parameter)
		{
			var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TypeName} Id.")));

			var model = unitOfWork.LevelTurn.GetByID(id);
			
			var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{nameof(LevelTurn.Turns)}.")));

			if (nr == 1)
				model.Turns = int.Parse(requiredTextReader.Read(new ReadConfig(6, nameof(LevelTurn.Turns))));
			
			unitOfWork.Save();
			
			commandRunner.RunCommand(nameof(LevelTurn).ToLowerInvariant());
		}
	}
}