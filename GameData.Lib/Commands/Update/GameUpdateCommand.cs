using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class GameUpdateCommand : DataCommand<Game>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public GameUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			consoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(consoleIO.ReadLine());
			var game = unitOfWork.Game.GetByID(id);
			consoleIO.WriteLine($"Select property number. 1-Name, 2-Description");
			var nr = int.Parse(consoleIO.ReadLine());
			consoleIO.WriteLine($"Type new value:");
			var text = consoleIO.ReadLine();
			if (nr == 1)
				game.Name = text;
			if (nr == 2)
				game.Description = text;
			unitOfWork.Save();
			consoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}