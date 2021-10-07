using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class StrategyInsertCommand : GameDataReaderCommand<Strategy>
	{
		public StrategyInsertCommand(
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
			GameDataUnit.Strategy.Insert(
				new Strategy
				{
					Name = TextReader.Read(nameof(Strategy.Name))
					, Description = TextReader.Read(nameof(Strategy.Description))
				});
			GameDataUnit.Save();
		}
	}
}