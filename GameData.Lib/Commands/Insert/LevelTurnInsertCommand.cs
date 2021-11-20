using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnInsertCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public LevelTurnInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.LevelTurn.Insert(
				new LevelTurn
				{
					LevelId = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.LevelId))))
					, DifficultyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.DifficultyId))))
					, Turns = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.Turns))))
				});
			unitOfWork.Save();
		}
	}
}