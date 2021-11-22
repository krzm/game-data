using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnReadCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public LevelTurnReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.LevelTurn.Get(includeProperties: "Level,Difficulty"))
			{
				consoleIO.WriteLine($"{nameof(LevelTurn.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Level.Name)} : {item.Level.Name}");
				consoleIO.WriteLine($"{nameof(Difficulty.Name)} : {item.Difficulty.Name}");
				consoleIO.WriteLine($"{nameof(LevelTurn.Turns)} : {item.Turns}");
			}
		}
	}
}