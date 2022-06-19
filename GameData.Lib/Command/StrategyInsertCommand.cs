using System;
using CLIFramework;
using CLIReader;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class StrategyInsertCommand 
	: DataCommand<Strategy>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IReader<string> textReader;
	private ICommandRunner commandRunner;

	public StrategyInsertCommand(
		TextCommand command
		, IGameDataUnitOfWork unitOfWork
		, IReader<string> textReader)
		: base(command)
	{
		ArgumentNullException.ThrowIfNull(unitOfWork);
		ArgumentNullException.ThrowIfNull(textReader);

		this.unitOfWork = unitOfWork;
		this.textReader = textReader;
	}

	public void SetCommandRunner(ICommandRunner commandRunner)
	{
		ArgumentNullException.ThrowIfNull(commandRunner);
		this.commandRunner = commandRunner;
	}
	
	public override void Execute(object parameter)
	{
		unitOfWork.Strategy.Insert(
			new Strategy
			{
				Name = textReader.Read(new ReadConfig(50, nameof(Strategy.Name)))
				, Description = textReader.Read(new ReadConfig(250, nameof(Strategy.Description)))
			});
		unitOfWork.Save();
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}