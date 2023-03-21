using SmartCity;
using UnitTestExample;

namespace MStest
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public void Setup()
        {
        }
        [DataTestMethod]
        [DataRow(GarbageType.BETON)]
        [DataRow(GarbageType.RURA)]
        public void Compact_DoesntWork_ForGarbageType(GarbageType type)
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var garbageType = type;
            var result = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, result);
        }

    }
}