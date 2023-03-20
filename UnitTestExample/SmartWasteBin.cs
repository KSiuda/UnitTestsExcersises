using SmartCity;

namespace UnitTestExample
{
	public class SmartWasteBin
	{
		public bool Compactor { get; set; }

		public string ErrorMessage { get; set; }

		private List<Garbage> Garbages { get; set; }
	

	public SmartWasteBin(bool compactor)
	{
		Compactor = compactor;
	}

	public bool Compact(GarbageType garbageType)
	{
		if (!Compactor) return false;

		if (garbageType == GarbageType.BETON)
		{
			return false;
		}
		else if (garbageType == GarbageType.RURA)
		{
			ErrorMessage = "Rury to nie tutaj";
			return false;
		}

		return true;
	}

	public void Empty()
	{
		if (Garbages.Any())
		{
			Garbages.ForEach(x => { x.Remove();});
		}

		if (Garbages.Any(x => x.GarbageType is GarbageType.BETON or GarbageType.RURA))
		{
			return;
		}

		Garbages.Clear();
	}

	public string Clean()
	{
		var message = "CLEANED";
		if (Garbages.Any())
		{
			message = "CAN'T CLEAN";
		}
		return message;
	}

	public bool ThrowGarbage(Garbage garbage)
	{
		Garbages.Add(garbage);
		return true;
	}
}

	
}