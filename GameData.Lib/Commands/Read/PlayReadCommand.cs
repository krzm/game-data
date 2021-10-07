using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class PlayReadCommand : GameDataIOCommand
	{
		public PlayReadCommand(
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
			foreach (var item in GameDataUnitOfWork.Play.Get(includeProperties: "Level,Difficulty,Strategy"))
			{
				ConsoleIO.WriteLine($"{nameof(Play.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Play.Description)} : {item.Description}");
				ConsoleIO.WriteLine($"{nameof(Difficulty)} : {item.Difficulty.Name}");
				ConsoleIO.WriteLine($"{nameof(Level)} : {item.Level.Name}");
				ConsoleIO.WriteLine($"{nameof(Strategy)} : {item.Strategy.Name}");
				ConsoleIO.WriteLine($"{nameof(Play.Start)} : {item.Start}");
				ConsoleIO.WriteLine($"{nameof(Play.End)} : {item.End}");
				ConsoleIO.WriteLine($"{nameof(Play.Time)} : {item.Time}");
			}
		}
	}
}