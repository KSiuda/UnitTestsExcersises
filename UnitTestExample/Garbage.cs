﻿namespace SmartCity
{
    public class Garbage
    {
		public GarbageType GarbageType { get; private set; }

        public Garbage(GarbageType garbageType)
        {
			GarbageType = garbageType;
        }

		public void Remove()
		{

		}
	}

	public enum GarbageType
	{
		BETON,
		RURA,
		PAPIER,
		SZMATKA,
		MJENSKO
	}
}
