using System.Collections.Generic;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class GameUpdateCommand : DataCommand<Game>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly ICommandRunner commandRunner;
        private readonly IReader<string> requiredTextReader;

		public GameUpdateCommand(
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

			var model = unitOfWork.Game.GetByID(id);
			
			var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{nameof(Game.Name)}, 2-{nameof(Game.Description)}.")));

			if (nr == 1)
				model.Name = requiredTextReader.Read(new ReadConfig(50, nameof(Game.Name)));
			if (nr == 2)
				model.Description = requiredTextReader.Read(new ReadConfig(250, nameof(Game.Description)));
			
			unitOfWork.Save();
			
			commandRunner.RunCommand(nameof(Game).ToLowerInvariant());
		}
	}
}