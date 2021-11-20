using Console.Lib;

namespace GameData.ConsoleApp
{
	public class OneWordCommandNames : IOneWordNames
	{
		public string[] GetInstance()
		{
			return new string[]
			{
				"Help".ToLowerInvariant()
				, "Clear".ToLowerInvariant()
				, "Exit".ToLowerInvariant()
			};
		}
	}
}