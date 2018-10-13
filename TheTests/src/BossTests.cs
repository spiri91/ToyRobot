using ToyRobot.Boss;
using ToyRobot.Logger;
using Xunit;
using ToyRobot.Table;
using ToyRobot.Robot;
using ToyRobot.Cell;
using System.Collections.Generic;
using System;

namespace BringChaos.src
{
    public class BossTests
    {
        [Fact]
        public void Should_Contruct_Boss()
        {
            var logger = new Logger();
            new Boss(logger, new Table(logger, new List<Cell>()), new Robot((a, b) => true, (a, b) => a * b));
        }

        [Fact]
        public void Should_Not_Construct_Boss_With_Bad_Arguments()
        {
            var logger = new Logger();
            Assert.Throws<Exception>(() => new Boss(null, null, null));
            Assert.Throws<Exception>(() => new Boss(logger, new Table(logger, new List<Cell>()), null));
            Assert.Throws<Exception>(() => new Boss(null, new Table(logger, new List<Cell>()), new Robot((a, b) => true, (a, b) => a * b)));
            Assert.Throws<Exception>(() => new Boss(logger, null, new Robot((a, b) => true, (a, b) => a * b)));
        }
    }
}
