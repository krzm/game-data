using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class StrategyReadCommand : GameDataIOCommand
	{
		public StrategyReadCommand(
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
			foreach (var item in GameDataUnitOfWork.Strategy.Get())
			{
				ConsoleIO.WriteLine($"{nameof(Strategy.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Strategy.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(Strategy.Description)} : {item.Description}");
			}
		}
	}
}