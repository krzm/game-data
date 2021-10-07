using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelTurnInsertCommand : GameDataReaderCommand<LevelTurn>
	{
		public LevelTurnInsertCommand(
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
			GameDataUnit.LevelTurn.Insert(
				new LevelTurn
				{
					LevelId = int.Parse(TextReader.Read(nameof(LevelTurn.LevelId)))
					, DifficultyId = int.Parse(TextReader.Read(nameof(LevelTurn.DifficultyId)))
					, Turns = int.Parse(TextReader.Read(nameof(LevelTurn.Turns)))
				});
			GameDataUnit.Save();
		}
	}
}