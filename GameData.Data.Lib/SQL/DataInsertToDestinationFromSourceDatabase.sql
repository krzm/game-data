DECLARE @DifficultiesCount INT= 0;
Select @DifficultiesCount =count(*) from [GameData].[dbo].Difficulties;
IF @DifficultiesCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].Difficulties (Name,Description)
		SELECT Name,Description FROM [GameData.Lib.GameDataContext].[dbo].Difficulties
	END;

DECLARE @GamesCount INT= 0;
Select @GamesCount =count(*) from [GameData].[dbo].Games;
IF @GamesCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].Games (Name,Description)
		SELECT Name,Description FROM [GameData.Lib.GameDataContext].[dbo].Games
	END;

DECLARE @LevelsCount INT= 0;
Select @LevelsCount =count(*) from [GameData].[dbo].Levels;
IF @LevelsCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].Levels (GameId,Name,Objective)
		SELECT GameId,Name,Objective FROM [GameData.Lib.GameDataContext].[dbo].Levels
	END;

DECLARE @LevelTurnsCount INT= 0;
Select @LevelTurnsCount =count(*) from [GameData].[dbo].LevelTurns;
IF @LevelTurnsCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].LevelTurns (LevelId,DifficultyId,Turns)
		SELECT LevelId,DifficultyId,Turns FROM [GameData.Lib.GameDataContext].[dbo].LevelTurns
	END;

DECLARE @StrategiesCount INT= 0;
Select @StrategiesCount =count(*) from [GameData].[dbo].Strategies;
IF @StrategiesCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].Strategies (Name,Description)
		SELECT Name,Description FROM [GameData.Lib.GameDataContext].[dbo].Strategies
	END;

DECLARE @StrategyItemsCount INT= 0;
Select @StrategyItemsCount =count(*) from [GameData].[dbo].StrategyItems;
IF @StrategyItemsCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].StrategyItems (Name,Description)
		SELECT Name,Description FROM [GameData.Lib.GameDataContext].[dbo].StrategyItems
	END;

DECLARE @StrategyStrategyItemsCount INT= 0;
Select @StrategyStrategyItemsCount =count(*) from [GameData].[dbo].StrategyStrategyItems;
IF @StrategyStrategyItemsCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].StrategyStrategyItems (StrategyId,StrategyItemId)
		SELECT StrategyId,StrategyItemId FROM [GameData.Lib.GameDataContext].[dbo].StrategyStrategyItems
	END;

DECLARE @PlaysCount INT= 0;
Select @PlaysCount =count(*) from [GameData].[dbo].Plays;
IF @PlaysCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].Plays (LevelId,DifficultyId,StrategyId,[Start],[End],TimeTicks,[Description])
		SELECT LevelId,DifficultyId,StrategyId,[Start],[End],TimeTicks,[Description] FROM [GameData.Lib.GameDataContext].[dbo].Plays
	END;

DECLARE @PlayStatsCount INT= 0;
Select @PlayStatsCount =count(*) from [GameData].[dbo].PlayStats;
IF @PlayStatsCount = 0
    BEGIN
		INSERT INTO [GameData].[dbo].PlayStats (PlayId,Win,TurnsPlayed,Resources,UnitsLost,UnitsLevelUps)
		SELECT 1,Win,TurnsPlayed,Resources,UnitsLost,UnitsLevelUps FROM [GameData.Lib.GameDataContext].[dbo].PlayStats
	END;