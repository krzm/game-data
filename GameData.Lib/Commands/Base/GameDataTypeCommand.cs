using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public abstract class GameDataTypeCommand<TEntity> : TypeCommand<TEntity>
	{
		protected readonly IGameDataUnitOfWork GameDataUnit;

		protected GameDataTypeCommand(IGameDataUnitOfWork unitOfWork, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
			GameDataUnit = unitOfWork;
		}
	}
}