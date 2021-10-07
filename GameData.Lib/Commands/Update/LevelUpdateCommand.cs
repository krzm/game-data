using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class LevelUpdateCommand : GameDataTypeCommand<Level>
	{
		public LevelUpdateCommand(
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
			var item = GameDataUnit.Level.GetByID(id);
			ConsoleIO.WriteLine($"Select property number. 1-{nameof(Level.Name)}, 2-{nameof(Level.Objective)}");
			var nr = int.Parse(ConsoleIO.ReadLine());
			ConsoleIO.WriteLine($"Type new value:");
			var text = ConsoleIO.ReadLine();
			if (nr == 1)
				item.Name = text;
			if (nr == 2)
				item.Objective = text;
			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}