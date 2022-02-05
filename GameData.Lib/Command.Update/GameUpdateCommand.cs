using System;
using System.Collections.Generic;
using CLIFramework;
using CLIHelper;
using CLIReader;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class GameUpdateCommand 
	: DataCommand<Game>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IReader<string> requiredTextReader;
	private ICommandRunner commandRunner;

	public GameUpdateCommand(
		TextCommand textCommand
		, IGameDataUnitOfWork unitOfWork
		, List<IReader<string>> textReaders)
		: base(textCommand)
	{
		ArgumentNullException.ThrowIfNull(unitOfWork);
		ArgumentNullException.ThrowIfNull(textReaders);

		this.unitOfWork = unitOfWork;
		requiredTextReader = textReaders[0];
	}

	public void SetCommandRunner(ICommandRunner commandRunner)
	{
		ArgumentNullException.ThrowIfNull(commandRunner);
		this.commandRunner = commandRunner;
	}
	
	public override void Execute(object parameter)
	{
		var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TextCommand.TypeName} Id.")));

		var model = unitOfWork.Game.GetByID(id);

		const string p1 = nameof(Game.Name);
		const string p2 = nameof(Game.Description);
		
		var nr = int.Parse(requiredTextReader.Read(new ReadConfig(6
			, $"Select property number. 1-{p1}, 2-{p2}.")));

		if (nr == 1)
			model.Name = requiredTextReader.Read(new ReadConfig(50, p1));
		if (nr == 2)
			model.Description = requiredTextReader.Read(new ReadConfig(250, p2));
		
		unitOfWork.Save();
		
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}