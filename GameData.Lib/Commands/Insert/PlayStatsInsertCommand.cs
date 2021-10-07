using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class PlayStatsInsertCommand : GameDataReaderCommand<PlayStats>
	{
		public PlayStatsInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{

			ConsoleIO.WriteLine($"Select {nameof(Play)} Id.");
			var id = int.Parse(ConsoleIO.ReadLine());
			var item = GameDataUnit.Play.GetByID(id);

			while (item == null)
			{
				ConsoleIO.WriteLine($"Id {id} doesn't exist.");
				ConsoleIO.WriteLine($"Select {nameof(Play)} Id.");
				id = int.Parse(ConsoleIO.ReadLine());
				item = GameDataUnit.Play.GetByID(id);
			}

			GameDataUnit.PlayStats.Insert(
				new PlayStats
				{
					PlayId = item.Id
					, Win = bool.Parse(TextReader.Read(nameof(PlayStats.Win)))
					, TurnsPlayed = int.Parse(TextReader.Read(nameof(PlayStats.TurnsPlayed)))
					, Resources= int.Parse(TextReader.Read(nameof(PlayStats.Resources)))
					, UnitsLost = int.Parse(TextReader.Read(nameof(PlayStats.UnitsLost)))
					, UnitsLevelUps = int.Parse(TextReader.Read(nameof(PlayStats.UnitsLevelUps)))
				});
			GameDataUnit.Save();
		}
	}
}