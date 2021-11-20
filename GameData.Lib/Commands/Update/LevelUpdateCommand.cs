using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelUpdateCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public LevelUpdateCommand(
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
			var item = unitOfWork.Level.GetByID(id);
			consoleIO.WriteLine($"Select property number. 1-{nameof(Level.Name)}, 2-{nameof(Level.Objective)}");
			var nr = int.Parse(consoleIO.ReadLine());
			consoleIO.WriteLine($"Type new value:");
			var text = consoleIO.ReadLine();
			if (nr == 1)
				item.Name = text;
			if (nr == 2)
				item.Objective = text;
			unitOfWork.Save();
			consoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}