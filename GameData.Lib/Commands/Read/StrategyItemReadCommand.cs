using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class StrategyItemReadCommand : GameDataIOCommand
	{
		public StrategyItemReadCommand(
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
			foreach (var item in GameDataUnitOfWork.StrategyItem.Get())
			{
				ConsoleIO.WriteLine($"{nameof(StrategyItem.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(StrategyItem.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(StrategyItem.Description)} : {item.Description}");
			}
		}
	}
}