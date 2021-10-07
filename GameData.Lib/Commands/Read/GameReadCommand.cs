using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class GameReadCommand : GameDataIOCommand
	{
		public GameReadCommand(
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
			foreach (var item in GameDataUnitOfWork.Game.Get())
			{
				ConsoleIO.WriteLine($"{nameof(Game.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Game.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(Game.Description)} : {item.Description}");
			}
		}
	}
}