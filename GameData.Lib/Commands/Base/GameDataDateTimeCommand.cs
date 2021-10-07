using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public abstract class GameDataDateTimeCommand<TEntity> : DateTimeReaderCommand<TEntity>
	{
		protected readonly IGameDataUnitOfWork GameDataUnit;

		protected GameDataDateTimeCommand(IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader
			, IReader<DateTime> datetimeReader) : base(unitOfWork, consoleIO, textReader, datetimeReader)
		{
			GameDataUnit = unitOfWork;
		}
	}
}