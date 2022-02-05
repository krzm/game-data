using System;
using CLIFramework;
using CLIHelper;
using CLIReader;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class PlayInsertCommand 
	: DataCommand<Play>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IReader<string> textReader;
	private ICommandRunner commandRunner;

	public PlayInsertCommand(
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
		unitOfWork.Play.Insert(
			new Play
			{
				LevelId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.LevelId))))
				, DifficultyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.DifficultyId))))
				, StrategyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(Play.StrategyId))))
				, Description = textReader.Read(new ReadConfig(250, nameof(Play.Description)))
			});
		unitOfWork.Save();
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}