using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;
using System;

namespace GameData.ConsoleApp
{
	public class PlayUpdateCommand : GameDataDateTimeCommand<Play>
	{
		public PlayUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader
			, IReader<DateTime> dateTimeReader) : base(unitOfWork, consoleIO, textReader, dateTimeReader)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			var description = nameof(Play.Description);
			var start = nameof(Play.Start);
			var end = nameof(Play.End);

			ConsoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(ConsoleIO.ReadLine());
			var item = GameDataUnit.Play.GetByID(id);
			
			while(item == null)
			{
				ConsoleIO.WriteLine($"Id {id} doesn't exist.");
				ConsoleIO.WriteLine($"Select {TypeName} Id.");
				id = int.Parse(ConsoleIO.ReadLine());
				item = GameDataUnit.Play.GetByID(id);
			}

			ConsoleIO.WriteLine($"Select property number. 1-{description}, 2-{start} , 3-{end}");
			var nr = int.Parse(ConsoleIO.ReadLine());

			if (nr == 1)
				item.Description = TextReader.Read(description);
			if (nr == 2)
				item.Start = DatetimeReader.Read(start);
			if (nr == 3)
				item.End = DatetimeReader.Read(end);

			if(item.Start.HasValue && item.End.HasValue)
			{
				item.TimeTicks = (item.End - item.Start).Value.Ticks;
			}

			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}