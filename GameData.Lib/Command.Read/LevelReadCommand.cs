using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class LevelReadCommand : DataCommand<Level>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IOutput output;

		public LevelReadCommand(
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
			foreach (var item in unitOfWork.Level.Get())
			{
				output.WriteLine($"{nameof(Level.Id)} : {item.Id}");
				output.WriteLine($"{nameof(Level.Name)} : {item.Name}");
				output.WriteLine($"{nameof(Level.Objective)} : {item.Objective}");
			}
		}
	}
}