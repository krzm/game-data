using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyItemInsertCommand : DataCommand<StrategyItem>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public StrategyItemInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.StrategyItem.Insert(
				new StrategyItem
				{
					Name = textReader.Read(new ReadConfig(50, nameof(StrategyItem.Name)))
					, Description = textReader.Read(new ReadConfig(250, nameof(StrategyItem.Description)))
				});
			unitOfWork.Save();
		}
	}
}