using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelTurnReadCommand : DataCommand<LevelTurn>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IOutput output;

		public LevelTurnReadCommand(
			TextCommand command
			, IGameDataUnitOfWork unitOfWork
			, IOutput output)
			: base(command)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(output);
			
			this.unitOfWork = unitOfWork;
			this.output = output;
		}

		public override void Execute(object parameter)
		{
			output.Clear();
			foreach (var item in unitOfWork.LevelTurn.Get(includeProperties: "Level,Difficulty"))
			{
				output.WriteLine($"{nameof(LevelTurn.Id)} : {item.Id}");
				output.WriteLine($"{nameof(Level.Name)} : {item.Level.Name}");
				output.WriteLine($"{nameof(Difficulty.Name)} : {item.Difficulty.Name}");
				output.WriteLine($"{nameof(LevelTurn.Turns)} : {item.Turns}");
			}
		}
	}
}