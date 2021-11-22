using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelInsertCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public LevelInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Level.Insert(
				new Level
				{
					GameId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Level.GameId))))
					, Name = textReader.Read(new ReadConfig(50, nameof(Level.Name)))
					, Objective = textReader.Read(new ReadConfig(250, nameof(Level.Objective)))
				});
			unitOfWork.Save();
		}
	}
}