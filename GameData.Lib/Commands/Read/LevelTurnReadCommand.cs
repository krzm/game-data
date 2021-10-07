using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelTurnReadCommand : GameDataIOCommand
	{
		public LevelTurnReadCommand(
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
			foreach (var item in GameDataUnitOfWork.LevelTurn.Get(includeProperties: "Level,Difficulty"))
			{
				ConsoleIO.WriteLine($"{nameof(LevelTurn.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Level.Name)} : {item.Level.Name}");
				ConsoleIO.WriteLine($"{nameof(Difficulty.Name)} : {item.Difficulty.Name}");
				ConsoleIO.WriteLine($"{nameof(LevelTurn.Turns)} : {item.Turns}");
			}
		}
	}
}