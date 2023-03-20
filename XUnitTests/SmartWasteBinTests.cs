using SmartCity;
using UnitTestExample;

namespace XUnitTests
{
    public class SmartWasteBinTests
    {

        [Theory]
        [InlineData(GarbageType.BETON)]
        [InlineData(GarbageType.RURA)]
        public void Compact_DoesntWork_ForGarbageType(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var wynik = bin.Compact(garbageType);

            //Assert
            Assert.False(wynik);
        }

        [Theory]
        [InlineData(GarbageType.MJENSKO)]
        [InlineData(GarbageType.PAPIER)]
        [InlineData(GarbageType.SZMATKA)]
        public void Compact_DoesWork_ForGarbageType(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(true);
            var wynik = bin.Compact(garbageType);

            //Assert
            Assert.True(wynik);
        }
    }
}