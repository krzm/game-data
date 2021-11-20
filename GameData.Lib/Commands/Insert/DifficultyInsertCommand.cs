using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class DifficultyInsertCommand : DataCommand<Difficulty>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public DifficultyInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Difficulty.Insert(
				new Difficulty
				{
					Name = textReader.Read(
						new ReadConfig(50, nameof(Difficulty.Name)))
					,
					Description = textReader.Read(
						new ReadConfig(250, nameof(Difficulty.Description)))
				});
			unitOfWork.Save();
		}
	}
}