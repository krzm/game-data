using System;
using CLIFramework;
using CLIReader;
using GameData.Lib.Repository;

namespace GameData.Lib;

public class LevelTurnInsertCommand 
	: DataCommand<LevelTurn>
{
	private readonly IGameDataUnitOfWork unitOfWork;
	private readonly IReader<string> textReader;
	private ICommandRunner commandRunner;

	public LevelTurnInsertCommand(
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
		unitOfWork.LevelTurn.Insert(
			new LevelTurn
			{
				LevelId = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.LevelId))))
				, DifficultyId = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.DifficultyId))))
				, Turns = int.Parse(textReader.Read(new ReadConfig(6, nameof(LevelTurn.Turns))))
			});
		unitOfWork.Save();
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}