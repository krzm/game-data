using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class GameReadCommand 
	: DataCommand<Game>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public GameReadCommand(
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
		foreach (var item in unitOfWork.Game.Get())
		{
			output.WriteLine($"{nameof(Game.Id)} : {item.Id}");
			output.WriteLine($"{nameof(Game.Name)} : {item.Name}");
			output.WriteLine($"{nameof(Game.Description)} : {item.Description}");
		}
	}
}