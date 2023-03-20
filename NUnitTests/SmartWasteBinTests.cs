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
        [TestCase(GarbageType.BETON), TestCase(GarbageType.RURA)]
        public void Compact_DoesntWork_ForBetonGarbageType(GarbageType type)
		{
			//Arrange
			var bin = new SmartWasteBin(true);
			var garbageType = type;
			var wynik = bin.Compact(garbageType);

			//Assert
			Assert.AreEqual(false,wynik);
		}
    }
}