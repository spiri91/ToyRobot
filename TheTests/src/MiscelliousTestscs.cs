﻿using System;
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
    }
}
