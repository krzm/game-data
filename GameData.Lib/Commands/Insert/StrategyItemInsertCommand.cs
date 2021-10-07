using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class StrategyItemInsertCommand : GameDataReaderCommand<StrategyItem>
	{
		public StrategyItemInsertCommand(
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
			GameDataUnit.StrategyItem.Insert(
				new StrategyItem
				{
					Name = TextReader.Read(nameof(StrategyItem.Name))
					, Description = TextReader.Read(nameof(StrategyItem.Description))
				});
			GameDataUnit.Save();
		}
	}
}