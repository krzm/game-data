using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class GameUpdateCommand : GameDataTypeCommand<Game>
	{
		public GameUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			ConsoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(ConsoleIO.ReadLine());
			var game = GameDataUnit.Game.GetByID(id);
			ConsoleIO.WriteLine($"Select property number. 1-Name, 2-Description");
			var nr = int.Parse(ConsoleIO.ReadLine());
			ConsoleIO.WriteLine($"Type new value:");
			var text = ConsoleIO.ReadLine();
			if (nr == 1)
				game.Name = text;
			if (nr == 2)
				game.Description = text;
			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}