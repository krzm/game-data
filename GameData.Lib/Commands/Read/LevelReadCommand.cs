using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelReadCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public LevelReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.Level.Get())
			{
				consoleIO.WriteLine($"{nameof(Level.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(Level.Name)} : {item.Name}");
				consoleIO.WriteLine($"{nameof(Level.Objective)} : {item.Objective}");
			}
		}
	}
}