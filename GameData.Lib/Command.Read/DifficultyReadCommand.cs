using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class DifficultyReadCommand 
	: DataCommand<Difficulty>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public DifficultyReadCommand(
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
		foreach (var item in unitOfWork.Difficulty.Get())
		{
			output.WriteLine($"{nameof(Difficulty.Id)} : {item.Id}");
			output.WriteLine($"{nameof(Difficulty.Name)} : {item.Name}");
			output.WriteLine($"{nameof(Difficulty.Description)} : {item.Description}");
		}
	}
}