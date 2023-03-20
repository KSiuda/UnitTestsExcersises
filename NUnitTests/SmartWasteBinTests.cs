using SmartCity;
using UnitTestExample;

namespace NUnitTests
{
	public class SmartWasteBinTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Compact_DoesntWork_ForBetonGarbageType()
		{
			//Arrange
			var bin = new SmartWasteBin(true);
			var garbageType = GarbageType.BETON;
			var wynik = bin.Compact(garbageType);

			//Assert
			Assert.AreEqual(false,wynik);
		}

		[Test]
		public void Compact_DoesntWork_ForRuraGarbageType()
		{
			//Arrange
			var bin = new SmartWasteBin(true);
			var garbageType = GarbageType.RURA;
			var wynik = bin.Compact(garbageType);

			//Assert
			Assert.AreEqual(false, wynik);
		}

		[Test]
		public void Test2()
		{

		}
	}
}