using ToyRobot.Cell;
using ToyRobot.misc;
using Xunit;

namespace BringChaos.src
{
    public class EmptyCellTests
    {
        [Fact]
        public void Should_Construct_Empty_Cell()
        {
            new EmptyCell();
        }

        [Fact] 
        public void Should_Return_True_When_Asked_If_Empty()
        {
            Assert.True(new EmptyCell().YouEmpty());
        }

        [Fact]
        public void Should_Change_Index()
        {
            var cell = new EmptyCell();
            cell.SetIndex(3);
            Assert.True(cell.Index == 3);
        }

        [Fact]
        public void Should_Draw_Itself_Correctly()
        {
            var testStr = "{99}";

            var cell = new EmptyCell();
            cell.SetIndex(99);
            
            Assert.True(cell.DrawYourself(testStr) == testStr.ToSpaces());

            cell.SetIndex(8);
            testStr = "{8}";

            Assert.True(cell.DrawYourself(testStr) == testStr.ToSpaces());
        }
    }
}
