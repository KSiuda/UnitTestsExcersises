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

        private static object[] IncorrectGarbageTypes =
        {
            new GarbageType[] { GarbageType.BETON, GarbageType.RURA }
        };

        private static object[] CorrectGarbageTypes =
        {
            new GarbageType[] {GarbageType.MJENSKO, GarbageType.PAPIER, GarbageType.SZMATKA}
        };

        [TestCase(GarbageType.BETON)]
        [TestCase(GarbageType.RURA)]
        public void Compact_DoesntWork_ForGarbageType(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var result = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, result);
        }


        [TestCase(GarbageType.MJENSKO)]
        [TestCase(GarbageType.PAPIER)]
        [TestCase(GarbageType.SZMATKA)]
        public void Compact_Work_ForGarbageType(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var result = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestCase(GarbageType.BETON)]
        [TestCase(GarbageType.RURA)]
        [TestCase(GarbageType.MJENSKO)]
        [TestCase(GarbageType.PAPIER)]
        [TestCase(GarbageType.SZMATKA)]
        public void Compact_DoesntWork_forCompactorFalse(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(false);
            var result = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestCaseSource(nameof(CorrectGarbageTypes))]
        public void Empty_Work_Empty(GarbageType type1, GarbageType type2, GarbageType type3)
        {
            var bin = new SmartWasteBin(true);
            var garbage1 = new Garbage(type1);
            var garbage2 = new Garbage(type2);
            var garbage3 = new Garbage(type3);

            bin.ThrowGarbage(garbage1);
            bin.ThrowGarbage(garbage2);
            bin.ThrowGarbage(garbage3);
            bin.Empty();

            var result = bin.Clean();

            Assert.AreEqual("CLEANED", result);
        }

        [TestCaseSource(nameof(IncorrectGarbageTypes))]
        public void Empty_DosentWork_Empty(GarbageType type1, GarbageType type2)
        {
            var bin = new SmartWasteBin(true);
            var garbage1 = new Garbage(type1);
            var garbage2 = new Garbage(type2);

            bin.ThrowGarbage(garbage1);
            bin.ThrowGarbage(garbage2);
            bin.Empty();

            var result = bin.Clean();

            Assert.AreEqual("CAN'T CLEAN", result);
        }

        [TestCase(GarbageType.BETON)]
        [TestCase(GarbageType.RURA)]
        [TestCase(GarbageType.MJENSKO)]
        [TestCase(GarbageType.PAPIER)]
        [TestCase(GarbageType.SZMATKA)]
        public void ThrowGarbage_Work_EveryGarbageType(GarbageType garbageType)
        {
            var bin = new SmartWasteBin(true);
            var garbage = new Garbage(garbageType);

            var result = bin.ThrowGarbage(garbage);

            Assert.AreEqual(true, result);
        }
    }
}