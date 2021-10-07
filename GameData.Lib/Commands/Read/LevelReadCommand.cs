using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelReadCommand : GameDataIOCommand
	{
		public LevelReadCommand(
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
			foreach (var item in GameDataUnitOfWork.Level.Get())
			{
				ConsoleIO.WriteLine($"{nameof(Level.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(Level.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(Level.Objective)} : {item.Objective}");
			}
		}
	}
}