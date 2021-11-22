using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyInsertCommand : DataCommand<Strategy>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public StrategyInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Strategy.Insert(
				new Strategy
				{
					Name = textReader.Read(new ReadConfig(50, nameof(Strategy.Name)))
					, Description = textReader.Read(new ReadConfig(250, nameof(Strategy.Description)))
				});
			unitOfWork.Save();
		}
	}
}