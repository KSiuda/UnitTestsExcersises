using System.Runtime.ExceptionServices;
using SmartCity;
using UnitTestExample;

namespace XUnitTests
{
    public class SmartWasteBinTests
    {

        public static IEnumerable<Object[]> GarbageTypes()
        {
            foreach (var garbageType in Enum.GetValues(typeof(GarbageType)))
            {
                yield return new[] { garbageType};
            }
        }

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
        [MemberData(nameof(GarbageTypes))]
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
            var bin = new SmartWasteBin(false)
            {
                Garbages = new List<Garbage>()
            };
            var result = bin.Clean();

            //assert
            Assert.Equal("CLEANED", result);
        }

        [Fact]
        public void CantCleanNonEmptyBin()
        {
            //arrange
            var bin = new SmartWasteBin(false)
            {
                Garbages = new List<Garbage>()
            };
            bin.ThrowGarbage(new Garbage(GarbageType.BETON));
            var result = bin.Clean();

            //assert
            Assert.Equal("CAN'T CLEAN", result);
        }

        [Theory]
        [MemberData(nameof(GarbageTypes))]
        public void CanThrowGarbage(GarbageType garbageType)
        {
            //Arrange
            Garbage garbage = new(garbageType);
            var bin = new SmartWasteBin(true)
            {
                Garbages = new List<Garbage>()
            };
            bin.ThrowGarbage(garbage);

            //Assert
            Assert.True(bin.Garbages.Any() && bin.Garbages.All(x => x.GarbageType == garbageType));
        }



        [Theory]
        [MemberData(nameof(GarbageTypes))]
        public void CanEmptyGarbage(GarbageType garbageType)
        {
            Garbage garbage = new(garbageType);
            var bin = new SmartWasteBin(true)
            {
                Garbages = new List<Garbage>()
            };
            bin.Empty();

            Assert.True(bin.Garbages.All(x => x.GarbageType is GarbageType.BETON or GarbageType.RURA));
        }
    }
}
