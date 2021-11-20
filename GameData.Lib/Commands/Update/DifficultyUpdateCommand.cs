using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
    public class DifficultyUpdateCommand : DataCommand<Difficulty>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;
		private readonly IReader<string> textReader;

		public DifficultyUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
			this.textReader = textReader;
		}

		public override void Execute(object parameter)
		{
			var name = nameof(Difficulty.Name);
			var description = nameof(Difficulty.Description);

			consoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(consoleIO.ReadLine());
			var game = unitOfWork.Difficulty.GetByID(id);

			consoleIO.WriteLine($"Select property number. 1-{name}, 2-{description}");
			var nr = int.Parse(consoleIO.ReadLine());
			if (nr == 1)
				game.Name = textReader.Read(new ReadConfig(50, name));
			if (nr == 2)
				game.Description = textReader.Read(new ReadConfig(250, description));
			
			unitOfWork.Save();
			consoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}