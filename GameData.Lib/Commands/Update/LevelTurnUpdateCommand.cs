using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnUpdateCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public LevelTurnUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			consoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(consoleIO.ReadLine());
			var item = unitOfWork.LevelTurn.GetByID(id);
			consoleIO.WriteLine($"Select property number. 1-Turns");
			var nr = int.Parse(consoleIO.ReadLine());
			consoleIO.WriteLine($"Type new value:");
			var text = consoleIO.ReadLine();
			if (nr == 1)
				item.Turns = int.Parse(text);
			unitOfWork.Save();
			consoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}