using System;
using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	//todo: use readers ?
	public class PlayStatsInsertCommand : DataCommand<PlayStats>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IOutput output;
		private readonly IInput input;
		private readonly IReader<string> textReader;
        private ICommandRunner commandRunner;

		public PlayStatsInsertCommand(
			TextCommand command
			, IGameDataUnitOfWork unitOfWork
			, IOutput output
			, IInput input
			, IReader<string> textReader)
			: base(command)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(output);
			ArgumentNullException.ThrowIfNull(input);
			ArgumentNullException.ThrowIfNull(textReader);

			this.unitOfWork = unitOfWork;
			this.output = output;
			this.input = input;
			this.textReader = textReader;
		}

		public void SetCommandRunner(ICommandRunner commandRunner)
		{
			ArgumentNullException.ThrowIfNull(commandRunner);
            this.commandRunner = commandRunner;
		}

		public override void Execute(object parameter)
		{

			output.WriteLine($"Select {nameof(Play)} Id.");
			var id = int.Parse(input.ReadLine());
			var item = unitOfWork.Play.GetByID(id);

			while (item == null)
			{
				output.WriteLine($"Id {id} doesn't exist.");
				output.WriteLine($"Select {nameof(Play)} Id.");
				id = int.Parse(input.ReadLine());
				item = unitOfWork.Play.GetByID(id);
			}

			unitOfWork.PlayStats.Insert(
				new PlayStats
				{
					PlayId = item.Id
					, Win = bool.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.Win))))
					, TurnsPlayed = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.TurnsPlayed))))
					, Resources= int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.Resources))))
					, UnitsLost = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.UnitsLost))))
					, UnitsLevelUps = int.Parse(textReader.Read(new ReadConfig(6, nameof(PlayStats.UnitsLevelUps))))
				});
			unitOfWork.Save();
			commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
		}
	}
}