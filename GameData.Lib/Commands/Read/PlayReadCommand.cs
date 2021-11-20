using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class PlayReadCommand : DataCommand<Play>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public PlayReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.Play.Get(includeProperties: "Level,Difficulty,Strategy"))
			{
				consoleIO.WriteLine($"{nameof(Play.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Play.Description)} : {item.Description}");
				consoleIO.WriteLine($"{nameof(Difficulty)} : {item.Difficulty.Name}");
				consoleIO.WriteLine($"{nameof(Level)} : {item.Level.Name}");
				consoleIO.WriteLine($"{nameof(Strategy)} : {item.Strategy.Name}");
				consoleIO.WriteLine($"{nameof(Play.Start)} : {item.Start}");
				consoleIO.WriteLine($"{nameof(Play.End)} : {item.End}");
				consoleIO.WriteLine($"{nameof(Play.Time)} : {item.Time}");
			}
		}
	}
}