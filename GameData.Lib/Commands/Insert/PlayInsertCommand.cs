using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{

	public class PlayInsertCommand : GameDataReaderCommand<Play>
	{
		public PlayInsertCommand(
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
			GameDataUnit.Play.Insert(
				new Play
				{
					LevelId = int.Parse(TextReader.Read(nameof(Play.LevelId)))
					, DifficultyId = int.Parse(TextReader.Read(nameof(Play.DifficultyId)))
					, StrategyId = int.Parse(TextReader.Read(nameof(Play.StrategyId)))
					, Description = TextReader.Read(nameof(Play.Description))
				});
			GameDataUnit.Save();
		}
	}
}