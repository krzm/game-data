using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public abstract class GameDataReaderCommand<TEntity> : DataReaderCommand<TEntity>
	{
		protected readonly IGameDataUnitOfWork GameDataUnit;

		protected GameDataReaderCommand(IGameDataUnitOfWork unitOfWork, IConsoleIO consoleIO, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
			GameDataUnit = unitOfWork;
		}
	}
}