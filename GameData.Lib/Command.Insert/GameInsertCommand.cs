using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
    public class GameInsertCommand : DataCommand<Game>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IReader<string> textReader;

		public GameInsertCommand(
			IGameDataUnitOfWork unitOfWork
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			unitOfWork.Game.Insert(
				new Game
				{
					Name = textReader.Read(new ReadConfig(50, nameof(Game.Name)))
					, Description =textReader.Read(new ReadConfig(250, nameof(Game.Description)))
				});
			unitOfWork.Save();
		}
	}
}