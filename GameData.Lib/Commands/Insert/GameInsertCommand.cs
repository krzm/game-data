using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class GameInsertCommand : GameDataReaderCommand<Game>
	{
		public GameInsertCommand(
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
			GameDataUnit.Game.Insert(
				new Game
				{
					Name = TextReader.Read(nameof(Game.Name))
					, Description =TextReader.Read(nameof(Game.Description))
				});
			GameDataUnit.Save();
		}
	}
}