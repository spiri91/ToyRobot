using System;
using ToyRobot.misc;
using Xunit;

namespace TheTests
{
    public class MiscelliousTests
    {
        [Fact]
        public void Should_Create_PointsTo()
        {
            new PointsTo(Cardinal.Est);
        }

        [Fact]
        public void Should_Expose_Cardinal_When_To_String()
        {
            var sut = new PointsTo(Cardinal.Est);

            var res = sut.ToString();

            Assert.True(res == "Est");

            var cardinal = Cardinal.Est;
            Assert.True(Enum.GetName(typeof(Cardinal), cardinal) == res);
        }

        [Fact]
        public void Should_Get_Correct_Direction_On_Change_Left()
        {
            Assert.True(new PointsTo(Cardinal.Est).GetLeftDirection().Cardinal == Cardinal.North);
            Assert.True(new PointsTo(Cardinal.West).GetLeftDirection().Cardinal == Cardinal.South);
            Assert.True(new PointsTo(Cardinal.South).GetLeftDirection().Cardinal == Cardinal.Est);
            Assert.True(new PointsTo(Cardinal.North).GetLeftDirection().Cardinal == Cardinal.West);

            Assert.True(new PointsTo(Cardinal.Nowhere).GetLeftDirection().Cardinal == Cardinal.Nowhere);
        }

        [Fact]
        public void Should_Get_Correct_Direction_On_Change_Right()
        {
            Assert.True(new PointsTo(Cardinal.Est).GetRightDirection().Cardinal == Cardinal.South);
            Assert.True(new PointsTo(Cardinal.West).GetRightDirection().Cardinal == Cardinal.North);
            Assert.True(new PointsTo(Cardinal.South).GetRightDirection().Cardinal == Cardinal.West);
            Assert.True(new PointsTo(Cardinal.North).GetRightDirection().Cardinal == Cardinal.Est);

            Assert.True(new PointsTo(Cardinal.Nowhere).GetLeftDirection().Cardinal == Cardinal.Nowhere);
        }

        [Fact]
        public void Should_Construct_StringEventArgs()
        {
            new StringEventsArgs("test");
            new StringEventsArgs(null);
        }

        [Fact]
        public void Should_ToString_StringEventArgs()
        {
            var test = new StringEventsArgs("test").ToString();
            var test2 = new StringEventsArgs(null).ToString();

            Assert.True("test" == test);
            Assert.True(string.Empty == test2);
        }

        [Fact]
        public void Should_ToSpaces_A_String()
        {
            var test1 = "1234";
            var test2 = "1";
            var test3 = string.Empty;
            var test4 = "123456789";
            string test5 = null; 

            Assert.True(test1.ToSpaces() == "    ");
            Assert.True(test2.ToSpaces() == " ");
            Assert.True(test3.ToSpaces() == string.Empty);
            Assert.True(test4.ToSpaces() == "         ");
            Assert.True(test5.ToSpaces() == string.Empty);
        }
    }
}
