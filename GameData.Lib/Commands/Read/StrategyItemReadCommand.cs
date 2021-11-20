﻿using Console.Lib;
using GameData.Lib.Repository;

namespace GameData.Lib
{
	public class StrategyItemReadCommand : DataCommand<Strategy>
	{
		private readonly IGameDataUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;

		public StrategyItemReadCommand(
			IGameDataUnitOfWork unitOfWork
			, IConsoleIO consoleIO)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in unitOfWork.StrategyItem.Get())
			{
				consoleIO.WriteLine($"{nameof(StrategyItem.Id)} : {item.Id}");
				consoleIO.WriteLine($"{nameof(StrategyItem.Name)} : {item.Name}");
				consoleIO.WriteLine($"{nameof(StrategyItem.Description)} : {item.Description}");
			}
		}
	}
}