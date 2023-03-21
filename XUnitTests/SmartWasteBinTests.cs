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

        [Theory]
        [InlineData(GarbageType.BETON)]
        [InlineData(GarbageType.RURA)]
        [InlineData(GarbageType.MJENSKO)]
        [InlineData(GarbageType.PAPIER)]
        [InlineData(GarbageType.SZMATKA)]
        public void Compact_DoesWork_ForCompactorFalse(GarbageType garbageType)
        {
            //Arrange
            var bin = new SmartWasteBin(false);
            var wynik = bin.Compact(garbageType);

            //Assert
            Assert.False(wynik);
        }

        [Fact]
        public void CanCleanEmptyBin()
        {
            //arrange
            var bin = new SmartWasteBin(false);
            var result = bin.Clean();

            //assert
            Assert.Equal("CLEANED", result);
        }

        [Fact]
        public void CantCleanNonEmptyBin()
        {
            //arrange
            var bin = new SmartWasteBin(false);
            bin.ThrowGarbage(new Garbage(GarbageType.BETON));
            var result = bin.Clean();

            //assert
            Assert.Equal("CAN'T CLEAN", result);
        }
    }
}