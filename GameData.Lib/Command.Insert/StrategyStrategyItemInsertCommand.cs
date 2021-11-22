using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyStrategyItemInsertCommand : DataCommand<StrategyStrategyItem>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public StrategyStrategyItemInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.StrategyStrategyItem.Insert(
				new StrategyStrategyItem
				{
					StrategyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(StrategyStrategyItem.StrategyId))))
					, StrategyItemId = int.Parse(textReader.Read(new ReadConfig(6, nameof(StrategyStrategyItem.StrategyItemId))))
				});
			unitOfWork.Save();
		}
	}
}