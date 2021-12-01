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
		private readonly IOutput output;
		private readonly IReader<string> requiredTextReader;
		private readonly IReader<string> optionalTextReader;
		private readonly IReader<DateTime?> optionalDateTimeReader;
        private ICommandRunner commandRunner;

		public PlayUpdateCommand(
			TextCommand textCommand
			, IGameDataUnitOfWork unitOfWork
			, IOutput output
			, List<IReader<string>> textReaders
			, List<IReader<DateTime?>> optionalDateTimeReader)
			: base(textCommand)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(output);
			ArgumentNullException.ThrowIfNull(textReaders);
			ArgumentNullException.ThrowIfNull(optionalDateTimeReader);

			this.unitOfWork = unitOfWork;
			this.output = output;
			requiredTextReader = textReaders[0];
			optionalTextReader = textReaders[1];
			this.optionalDateTimeReader = optionalDateTimeReader[0];
		}
		
		public void SetCommandRunner(ICommandRunner commandRunner)
		{
			ArgumentNullException.ThrowIfNull(commandRunner);
            this.commandRunner = commandRunner;
		}

		public override void Execute(object parameter)
		{
			var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TextCommand.TypeName} Id.")));
			
			var model = unitOfWork.Play.GetByID(id);

			while (model == null)
			{
				output.WriteLine($"Id {id} doesn't exist.");
				output.WriteLine($"Select {TextCommand.TypeName} Id.");
				id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TextCommand.TypeName} Id.")));
				model = unitOfWork.Play.GetByID(id);
			}

			var p1 = nameof(Play.Description);
			var p2 = nameof(Play.Start);
			var p3 = nameof(Play.End);

			var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
				, $"Select property number. 1-{p1}, 2-{p2}, 3-{p3}.")));

			if (nr == 1)
				model.Description = requiredTextReader.Read(new ReadConfig(250, p1));
			if (nr == 2)
				model.Start = optionalDateTimeReader.Read(
					new ReadConfig(16, p2, Format, DateTime.Now.ToString(Format)));
			if (nr == 3)
				model.End = optionalDateTimeReader.Read(
					new ReadConfig(16, p3, Format, DateTime.Now.ToString(Format)));

			if (model.Start.HasValue && model.End.HasValue)
			{
				model.TimeTicks = (model.End - model.Start).Value.Ticks;
			}

			unitOfWork.Save();

			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}