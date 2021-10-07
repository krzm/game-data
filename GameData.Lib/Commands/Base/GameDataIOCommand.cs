using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public abstract class GameDataIOCommand : DataIOCommand
	{
		protected readonly IGameDataUnitOfWork GameDataUnitOfWork;

		protected GameDataIOCommand(IGameDataUnitOfWork unitOfWork, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
			GameDataUnitOfWork = unitOfWork;
		}
	}
}