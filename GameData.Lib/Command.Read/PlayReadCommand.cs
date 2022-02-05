using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class PlayReadCommand 
	: DataCommand<Play>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public PlayReadCommand(
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
		foreach (var item in unitOfWork.Play.Get(includeProperties: "Level,Difficulty,Strategy"))
		{
			output.WriteLine($"{nameof(Play.Id)} : {item.Id}");
			output.WriteLine($"{nameof(Play.Description)} : {item.Description}");
			output.WriteLine($"{nameof(Difficulty)} : {item.Difficulty.Name}");
			output.WriteLine($"{nameof(Level)} : {item.Level.Name}");
			output.WriteLine($"{nameof(Strategy)} : {item.Strategy.Name}");
			output.WriteLine($"{nameof(Play.Start)} : {item.Start}");
			output.WriteLine($"{nameof(Play.End)} : {item.End}");
			output.WriteLine($"{nameof(Play.Time)} : {item.Time}");
		}
	}
}