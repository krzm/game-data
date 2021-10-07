using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class DifficultyInsertCommand : GameDataReaderCommand<Difficulty>
	{
		public DifficultyInsertCommand(
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
			GameDataUnit.Difficulty.Insert(
				new Difficulty
				{
					Name = TextReader.Read(nameof(Difficulty.Name))
					, Description = TextReader.Read(nameof(Difficulty.Description))
				});
			UnitOfWork.Save();
		}
	}
}