using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class StrategyStrategyItemInsertCommand : GameDataReaderCommand<StrategyStrategyItem>
	{
		public StrategyStrategyItemInsertCommand(
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
			GameDataUnit.StrategyStrategyItem.Insert(
				new StrategyStrategyItem
				{
					StrategyId = int.Parse(TextReader.Read(nameof(StrategyStrategyItem.StrategyId)))
					, StrategyItemId = int.Parse(TextReader.Read(nameof(StrategyStrategyItem.StrategyItemId)))
				});
			GameDataUnit.Save();
		}
	}
}