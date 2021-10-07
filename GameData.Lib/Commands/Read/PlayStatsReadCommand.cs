using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class PlayStatsReadCommand : GameDataIOCommand
	{
		public PlayStatsReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in GameDataUnitOfWork.PlayStats.Get(includeProperties: "Play"))
			{
				ConsoleIO.WriteLine($"{nameof(PlayStats.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.PlayId)} : {item.PlayId}");
				ConsoleIO.WriteLine($"{nameof(Play.Description)} : {item.Play.Description}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.Win)} : {item.Win}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.TurnsPlayed)} : {item.TurnsPlayed}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.Resources)} : {item.Resources}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.UnitsLost)} : {item.UnitsLost}");
				ConsoleIO.WriteLine($"{nameof(PlayStats.UnitsLevelUps)} : {item.UnitsLevelUps}");
			}
		}
	}
}