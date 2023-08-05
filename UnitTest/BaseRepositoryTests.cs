using CatsAndDogs.Data.Repository;
using System.IO;
namespace UnitTest
{
    public class BaseRepositoryTests
    {
        [Fact]
        public void FilteredString()
        {
            BaseRepository BR = new BaseRepository();
            var testData = BR.FilteredString("<Completed>test\r\n<Completed>");
            bool Value = testData == "test";
            Assert.True(Value);
        }

        [Fact]
        public void SplitRows()
        {
            BaseRepository BR = new BaseRepository();
            var testData = BR.SplitRows("Test0<DataRow>Test1<DataRow>Test2<DataRow>");
            bool Row0 = testData[0] == "Test0";
            bool Row1 = testData[1] == "Test1";
            bool Row2 = testData[2] == "Test2";
            Assert.True(Row0);
            Assert.True(Row1);
            Assert.True(Row2);
        }


    }
}