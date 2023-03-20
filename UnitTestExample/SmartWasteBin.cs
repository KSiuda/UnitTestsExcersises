namespace UnitTestExample
{
	public class SmartWasteBin
	{
		public bool Compactor { get; set; }

		public string ErrorMessage { get; set; }

		public SmartWasteBin(bool compactor)
		{
			Compactor = compactor;
		}

		public bool Compact(string garbageType)
		{
			if (!Compactor) return false;

			if (garbageType.ToUpper() == "BETON")
			{
				return false;
			}
			else if (garbageType.ToUpper() == "RURA")
			{
				ErrorMessage = "Rury to nie tutaj";
				return false;
			}

			return true;
		}
	}
}