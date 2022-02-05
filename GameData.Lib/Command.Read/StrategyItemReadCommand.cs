using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class StrategyItemReadCommand 
	: DataCommand<Strategy>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public StrategyItemReadCommand(
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
		foreach (var item in unitOfWork.StrategyItem.Get())
		{
			output.WriteLine($"{nameof(StrategyItem.Id)} : {item.Id}");
			output.WriteLine($"{nameof(StrategyItem.Name)} : {item.Name}");
			output.WriteLine($"{nameof(StrategyItem.Description)} : {item.Description}");
		}
	}
}