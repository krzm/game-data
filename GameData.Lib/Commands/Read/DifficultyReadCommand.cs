using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class DifficultyReadCommand : GameDataIOCommand
	{
		public DifficultyReadCommand(
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
			foreach (var item in GameDataUnitOfWork.Difficulty.Get())
			{
				ConsoleIO.WriteLine($"{nameof(Difficulty.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Difficulty.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(Difficulty.Description)} : {item.Description}");
			}
		}
	}
}