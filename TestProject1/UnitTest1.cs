

using SmartCity;
using UnitTestExample;

namespace MSTests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public void Setup()
        {
        }
        [TestMethod]
        public void Compact_DoesntWork_ForBetonGarbageType()
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var garbageType = GarbageType.BETON;
            var wynik = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, wynik);
        }
        [TestMethod]
        public void Compact_DoesntWork_ForRuraGarbageType()
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var garbageType = GarbageType.RURA;
            var wynik = bin.Compact(garbageType);

            //Assert
            Assert.AreEqual(false, wynik);
        }

    }
}