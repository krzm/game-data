using Console.Lib;
using GameData.Lib.Repository;
using System;
using System.Collections.Generic;

namespace GameData.Lib
{
	public class PlayUpdateCommand : DataCommand<Play>
	{
		private const string Format = "dd.MM.yyyy HH:mm";
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly ICommandRunner commandRunner;
		private readonly IConsoleIO consoleIO;
		private readonly IReader<string> requiredTextReader;
		private readonly IReader<string> optionalTextReader;
		private readonly IReader<DateTime?> optionalDateTimeReader;

		public PlayUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, ICommandRunner commandRunner
			, IConsoleIO consoleIO
			, List<IReader<string>> textReader
			, List<IReader<DateTime?>> optionalDateTimeReader)
		{
			this.unitOfWork = unitOfWork;
			this.commandRunner = commandRunner;
			this.consoleIO = consoleIO;
			requiredTextReader = textReader[0];
			optionalTextReader = textReader[1];
			this.optionalDateTimeReader = optionalDateTimeReader[0];
		}

		public override void Execute(object parameter)
		{
			var description = nameof(Play.Description);
			var start = nameof(Play.Start);
			var end = nameof(Play.End);

			var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TypeName} Id.")));
			var model = unitOfWork.Play.GetByID(id);

			while (model == null)
			{
				consoleIO.WriteLine($"Id {id} doesn't exist.");
				consoleIO.WriteLine($"Select {TypeName} Id.");
				id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TypeName} Id.")));
				model = unitOfWork.Play.GetByID(id);
			}

			var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{description}, 2-{start}, 3-{end}.")));
			if (nr == 1)
				model.Description = requiredTextReader.Read(new ReadConfig(250, nameof(Play.Description)));
			if (nr == 2)
				model.Start = optionalDateTimeReader.Read(
					new ReadConfig(16, nameof(Play.Start), Format: Format, DefaultValue: DateTime.Now.ToString(Format))
				);
			if (nr == 3)
				model.End = optionalDateTimeReader.Read(
					new ReadConfig(16, nameof(Play.End), Format: Format, DefaultValue: DateTime.Now.ToString(Format))
				);

			if (model.Start.HasValue && model.End.HasValue)
			{
				model.TimeTicks = (model.End - model.Start).Value.Ticks;
			}

			unitOfWork.Save();
			commandRunner.RunCommand(nameof(Play).ToLowerInvariant());
		}
	}
}