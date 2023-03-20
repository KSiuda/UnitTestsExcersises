using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity
{
	internal class Garbage
	{
		public GarbageType GarbageType { get; private set; }
		public Garbage() { }

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
