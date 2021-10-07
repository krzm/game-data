using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelTurnUpdateCommand : GameDataTypeCommand<LevelTurn>
	{
		public LevelTurnUpdateCommand(
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
			var item = GameDataUnit.LevelTurn.GetByID(id);
			ConsoleIO.WriteLine($"Select property number. 1-Turns");
			var nr = int.Parse(ConsoleIO.ReadLine());
			ConsoleIO.WriteLine($"Type new value:");
			var text = ConsoleIO.ReadLine();
			if (nr == 1)
				item.Turns = int.Parse(text);
			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}