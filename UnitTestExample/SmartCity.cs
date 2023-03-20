namespace UnitTestExample
{
	public class SmartCity
	{
		public void Do()
		{
			var bin = new SmartWasteBin(true);
			bin.Compact("niebeton");
		}
	}
}
