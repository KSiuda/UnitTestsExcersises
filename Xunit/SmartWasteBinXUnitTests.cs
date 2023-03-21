using SmartCity;
using UnitTestExample;

namespace XUnitTests
{
    public class SmartWasteBinTests
    {
        private SmartWasteBin bin;
        public SmartWasteBinTests()
        {
             bin = new SmartWasteBin(true);
        }

        [Theory]
        [InlineData(GarbageType.BETON, false)]
        [InlineData(GarbageType.RURA, false)]
        [InlineData(GarbageType.PAPIER, true)]
        [InlineData(GarbageType.MJENSKO, true)]
        [InlineData(GarbageType.SZMATKA, true)]
        public void Compact_DoesntWork_ForGarbageType(GarbageType type, bool expectedResult)
        {
            //Arrange
            var result = bin.Compact(type);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GarbageType.BETON, false)]
        [InlineData(GarbageType.RURA, true)]
        public void ErrorMessage_SetCorrectly(GarbageType type, bool expectedResult)
        {
            //Arrange
            bin.Compact(type);

            //Assert
            Assert.Equal(expectedResult, bin.ErrorMessage != null);
        }

        [Fact]
        public void Compactor_DoesntWork_WhenMissingCompactor()
        {
            bin.Compactor = false;
            var result = bin.Compact(GarbageType.BETON);

            Assert.False(result);
        }

        [Theory]
        [InlineData(GarbageType.BETON, true)]
        [InlineData(GarbageType.PAPIER, true)]
        public void Throw_Garbage_AddGarbageToGarbageList(GarbageType type, bool expectedResult)
        {
            // Arrange
            var result = bin.ThrowGarbage(new Garbage(type));

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GarbageType.BETON, "CAN'T CLEAN")]
        [InlineData(GarbageType.RURA, "CAN'T CLEAN")]
        [InlineData(GarbageType.PAPIER, "CLEANED")]
        [InlineData(GarbageType.MJENSKO, "CLEANED")]
        [InlineData(GarbageType.SZMATKA, "CLEANED")]
        public void Empty_EmptiesGarbageList(GarbageType type, string expectedResult)
        {
            // Arrange
            bin.ThrowGarbage(new Garbage(type));

            // Act
            bin.Empty();

            // Assert
            var result = bin.Clean();
            Assert.Equal(expectedResult, result);
        }
    }
}