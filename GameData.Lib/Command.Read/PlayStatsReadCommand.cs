using System;
using CLIFramework;
using CLIHelper;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class PlayStatsReadCommand 
	: DataCommand<PlayStats>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IOutput output;

	public PlayStatsReadCommand(
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
		foreach (var item in unitOfWork.PlayStats.Get(includeProperties: "Play"))
		{
			output.WriteLine($"{nameof(PlayStats.Id)} : {item.Id}");
			output.WriteLine($"{nameof(PlayStats.PlayId)} : {item.PlayId}");
			output.WriteLine($"{nameof(Play.Description)} : {item.Play.Description}");
			output.WriteLine($"{nameof(PlayStats.Win)} : {item.Win}");
			output.WriteLine($"{nameof(PlayStats.TurnsPlayed)} : {item.TurnsPlayed}");
			output.WriteLine($"{nameof(PlayStats.Resources)} : {item.Resources}");
			output.WriteLine($"{nameof(PlayStats.UnitsLost)} : {item.UnitsLost}");
			output.WriteLine($"{nameof(PlayStats.UnitsLevelUps)} : {item.UnitsLevelUps}");
		}
	}
}