using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class PlayStatsInsertCommand : DataCommand<PlayStats>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;
		private readonly IReader<string> textReader;

		public PlayStatsInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{

			consoleIO.WriteLine($"Select {nameof(Play)} Id.");
			var id = int.Parse(consoleIO.ReadLine());
			var item = unitOfWork.Play.GetByID(id);

			while (item == null)
			{
				consoleIO.WriteLine($"Id {id} doesn't exist.");
				consoleIO.WriteLine($"Select {nameof(Play)} Id.");
				id = int.Parse(consoleIO.ReadLine());
				item = unitOfWork.Play.GetByID(id);
			}

			unitOfWork.PlayStats.Insert(
				new PlayStats
				{
					PlayId = item.Id
					, Win = bool.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.Win))))
					, TurnsPlayed = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.TurnsPlayed))))
					, Resources= int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.Resources))))
					, UnitsLost = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.UnitsLost))))
					, UnitsLevelUps = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.UnitsLevelUps))))
				});
			unitOfWork.Save();
		}
	}
}