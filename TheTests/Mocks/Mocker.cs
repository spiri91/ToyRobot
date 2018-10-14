using System;
using System.Collections.Generic;
using ToyRobot.Boss;
using ToyRobot.Cell;
using ToyRobot.Logger;
using ToyRobot.Orchestrator;
using ToyRobot.Robot;
using ToyRobot.src.Logger;
using ToyRobot.Table;

namespace TheTests.Mocks
{
    public static class Mocker
    {
        public static Boss boss;
        public static EmptyCell cell;
        public static Table table;
        public static Robot robot;
        public static ILogger logger;
        public static Orchestrator orchestrator;

        static Mocker()
        {
            logger = new MockedLogger();
            table = new Table(logger, new List<Cell>());
            robot = new Robot(new Random().Next(1, 100), (x, y) => true, (x, y) => x * y);
            orchestrator = new Orchestrator();

            boss = new Boss(logger, table, robot);
        }
    }
}
