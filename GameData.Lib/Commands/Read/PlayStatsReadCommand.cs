using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class PlayStatsReadCommand : DataCommand<PlayStats>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public PlayStatsReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.PlayStats.Get(includeProperties: "Play"))
			{
				consoleIO.WriteLine($"{nameof(PlayStats.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(PlayStats.PlayId)} : {item.PlayId}");
				consoleIO.WriteLine($"{nameof(Play.Description)} : {item.Play.Description}");
				consoleIO.WriteLine($"{nameof(PlayStats.Win)} : {item.Win}");
				consoleIO.WriteLine($"{nameof(PlayStats.TurnsPlayed)} : {item.TurnsPlayed}");
				consoleIO.WriteLine($"{nameof(PlayStats.Resources)} : {item.Resources}");
				consoleIO.WriteLine($"{nameof(PlayStats.UnitsLost)} : {item.UnitsLost}");
				consoleIO.WriteLine($"{nameof(PlayStats.UnitsLevelUps)} : {item.UnitsLevelUps}");
			}
		}
	}
}