using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class PlayInsertCommand : DataCommand<Play>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public PlayInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Play.Insert(
				new Play
				{
					LevelId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.LevelId))))
					, DifficultyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.DifficultyId))))
					, StrategyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.StrategyId))))
					, Description = textReader.Read(new ReadConfig(250, nameof(Play.Description)))
				});
			unitOfWork.Save();
		}
	}
}