using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class DifficultyReadCommand : DataCommand<Difficulty>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public DifficultyReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.Difficulty.Get())
			{
				consoleIO.WriteLine($"{nameof(Difficulty.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Difficulty.Name)} : {item.Name}");
				consoleIO.WriteLine($"{nameof(Difficulty.Description)} : {item.Description}");
			}
		}
	}
}