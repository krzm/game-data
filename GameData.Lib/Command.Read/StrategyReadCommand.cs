using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyReadCommand : DataCommand<Strategy>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public StrategyReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.Strategy.Get())
			{
				consoleIO.WriteLine($"{nameof(Strategy.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Strategy.Name)} : {item.Name}");
				consoleIO.WriteLine($"{nameof(Strategy.Description)} : {item.Description}");
			}
		}
	}
}