﻿using System;
using ToyRobot.Command;
using Xunit;

namespace BringChaos.src
{
    public class PlaceCommandTests
    {
        [Fact]
        public void Should_Construct_PlaceCommand()
        {
            new PlaceCommand(new ToyRobot.misc.PointsTo(ToyRobot.misc.Cardinal.Est), 1, 1);
        }

        [Fact]
        public void Should_Not_Construct_PlaceCommand()
        {
            Assert.Throws<Exception>(() => new PlaceCommand(null, 1, 1));
        }

        [Fact]
        public void Should_Return_True_When_Asked_If_Valid()
        {
            var sut = new PlaceCommand(new ToyRobot.misc.PointsTo(ToyRobot.misc.Cardinal.Est), 1, 1);

            Assert.True(sut.YouValid());
        }

        [Fact]
        public void Should_Set_Correct_Indexes()
        {
            var sut = new PlaceCommand(new ToyRobot.misc.PointsTo(ToyRobot.misc.Cardinal.Est), 3, 4);
            Assert.True(sut.XPosition == 3);
            Assert.True(sut.YPosition == 4);
        }

        [Fact]
        public void Should_Parse_String_Commands()
        {
            var res = CommandParser.Parse("Place 3 4 n");
            Assert.True(res is PlaceCommand);

            Assert.True((res as PlaceCommand).XPosition == 3);
            Assert.True((res as PlaceCommand).YPosition == 4);
            Assert.True((res as PlaceCommand).PointingTo.Cardinal == ToyRobot.misc.Cardinal.North);
        }
    }
}
