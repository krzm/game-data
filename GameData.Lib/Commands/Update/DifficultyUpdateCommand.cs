using Console.Lib;
using GameData.Lib;
using GameData.Lib.Repository;

namespace GameData.ConsoleApp
{
	public class DifficultyUpdateCommand : GameDataReaderCommand<Difficulty>
	{
		public DifficultyUpdateCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			var name = nameof(Difficulty.Name);
			var description = nameof(Difficulty.Description);

			ConsoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(ConsoleIO.ReadLine());
			var game = GameDataUnit.Difficulty.GetByID(id);

			ConsoleIO.WriteLine($"Select property number. 1-{name}, 2-{description}");
			var nr = int.Parse(ConsoleIO.ReadLine());
			if (nr == 1)
				game.Name = TextReader.Read(name);
			if (nr == 2)
				game.Description = TextReader.Read(description);
			
			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}