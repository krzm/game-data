using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelInsertCommand : GameDataReaderCommand<Level>
	{
		public LevelInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			GameDataUnit.Level.Insert(
				new Level
				{
					GameId = int.Parse(TextReader.Read(nameof(Level.GameId)))
					, Name = TextReader.Read(nameof(Level.Name))
					, Objective = TextReader.Read(nameof(Level.Objective))
				});
			GameDataUnit.Save();
		}
	}
}