using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class GameReadCommand : DataCommand<Game>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public GameReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.Game.Get())
			{
				consoleIO.WriteLine($"{nameof(Game.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Game.Name)} : {item.Name}");
				consoleIO.WriteLine($"{nameof(Game.Description)} : {item.Description}");
			}
		}
	}
}