using System.Collections.Generic;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelUpdateCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
        private readonly ICommandRunner commandRunner;
        private readonly IReader<string> requiredTextReader;

		public LevelUpdateCommand(
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
			var id = int.Parse(requiredTextReader.Read(
				new ReadConfig(6, $"Select {TypeName} Id.")));

			var model = unitOfWork.Level.GetByID(id);

            const string p1 = nameof(Level.Name);
            const string p2 = nameof(Level.Objective);

            var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{p1}, 2-{p2}.")));

			if (nr == 1)
				model.Name = requiredTextReader.Read(new ReadConfig(50, p1));
			if (nr == 2)
				model.Objective = requiredTextReader.Read(new ReadConfig(250, p2));

			unitOfWork.Save();

			commandRunner.RunCommand(nameof(Level).ToLowerInvariant());
		}
	}
}