using SmartCity;
using UnitTestExample;

namespace MStest
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        private static TestContext _testContext;
        private static SmartWasteBin bin;
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _testContext = testContext;
        }
        [TestInitialize]
        public void SetupTest()
        {
            bin = new SmartWasteBin(true);
        }

        [TestMethod]
        public void Compact_DoesntWork_ForGarbageType()
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var garbageType = GarbageType.BETON;
            var result = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, result);
        }


        [DataTestMethod]
        [DataRow(GarbageType.BETON, false)]
        [DataRow(GarbageType.RURA, false)]
        [DataRow(GarbageType.PAPIER, true)]
        [DataRow(GarbageType.MJENSKO, true)]
        [DataRow(GarbageType.SZMATKA, true)]
        public void Compact_DoesntWork_ForGarbageType(GarbageType type, bool expectedResult)
        {
            //Arrange
            var result = bin.Compact(type);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(GarbageType.BETON, false)]
        [DataRow(GarbageType.RURA, true)]
        public void ErrorMessage_SetCorrectly(GarbageType type, bool expectedResult)
        {
            //Arrange
            bin.Compact(type);

            //Assert
            Assert.AreEqual(expectedResult, bin.ErrorMessage != null);
        }

        [TestMethod]
        public void Compactor_DoesntWork_WhenMissingCompactor()
        {
            bin.Compactor = false;
            var result = bin.Compact(GarbageType.BETON);

            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(GarbageType.BETON, true)]
        [DataRow(GarbageType.PAPIER, true)]
        public void Throw_Garbage_AddGarbageToGarbageList(GarbageType type, bool expectedResult)
        {
            // Arrange
            var result = bin.ThrowGarbage(new Garbage(type));

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(GarbageType.PAPIER, "CLEANED")]
        [DataRow(GarbageType.MJENSKO, "CLEANED")]
        [DataRow(GarbageType.SZMATKA, "CLEANED")]
        [DataRow(GarbageType.BETON, "CAN'T CLEAN")]
        [DataRow(GarbageType.RURA, "CAN'T CLEAN")]
        public void Empty_EmptiesGarbageList(GarbageType type, string expectedResult)
        {
            // Arrange
            bin.ThrowGarbage(new Garbage(type));

            // Act
            bin.Empty();

            // Assert
            var result = bin.Clean();
            Assert.AreEqual(expectedResult, result);
        }

    }
}