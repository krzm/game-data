using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class StrategyReadCommand 
	: DataCommand<Strategy>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public StrategyReadCommand(
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
		foreach (var item in unitOfWork.Strategy.Get())
		{
			output.WriteLine($"{nameof(Strategy.Id)} : {item.Id}");
			output.WriteLine($"{nameof(Strategy.Name)} : {item.Name}");
			output.WriteLine($"{nameof(Strategy.Description)} : {item.Description}");
		}
	}
}