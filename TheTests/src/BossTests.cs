using ToyRobot.Boss;
using ToyRobot.Logger;
using Xunit;
using ToyRobot.Table;
using ToyRobot.Robot;
using ToyRobot.Cell;
using System.Collections.Generic;
using System;
using TheTests.Mocks;

namespace BringChaos.src
{
    public class BossTests
    {
        [Fact]
        public void Should_Contruct_Boss()
        {
            var logger = Mocker.logger;
            new Boss(logger, Mocker.table, Mocker.robot);
        }

        [Fact]
        public void Should_Not_Construct_Boss_With_Bad_Arguments()
        {
            var logger = new Logger();
            Assert.Throws<Exception>(() => new Boss(null, null, null));
            Assert.Throws<Exception>(() => new Boss(logger, Mocker.table, null));
            Assert.Throws<Exception>(() => new Boss(null, Mocker.table, Mocker.robot));
            Assert.Throws<Exception>(() => new Boss(logger, null, Mocker.robot));
        }
    }
}
