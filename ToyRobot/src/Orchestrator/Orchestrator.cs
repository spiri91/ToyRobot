using System;
using System.Collections.Generic;
using Pipe4Net;
using ToyRobot.Cell;
using ToyRobot.src.Logger;

namespace ToyRobot.Orchestrator
{
    public class Orchestrator
    {
        private Boss.Boss _boss;

        private static int _numberOfCells = 25;
        private static int _rowAndColumMaxIndex = 5;

        public Orchestrator() : this(new Logger.Logger()) { }

        private static Func<int, int, bool> _validMove = (xIndex, yIndex) =>
        {
            var newIndex = _calculateIndex(xIndex, yIndex);

            if (newIndex > _numberOfCells) return false;

            if (xIndex > _rowAndColumMaxIndex || xIndex < 1) return false;

            if (yIndex > _rowAndColumMaxIndex || yIndex < 1) return false;

            return true;
        };

        private static Func<int, int, int> _calculateIndex = (xIndex, yIndex) =>
        {
            var newIndex = xIndex + 5 * (yIndex - 1);

            return newIndex;
        };

        public Orchestrator(ILogger logger)
        {
            var cells = new List<Cell.Cell>();
            _numberOfCells.GenerateForLoop(() => cells.Add(new EmptyCell()));

            var robot = new Robot.Robot(_validMove, _calculateIndex);
            cells.Add(robot);

            var table = new Table.Table(logger, cells);
            _boss = new Boss.Boss(logger, table, robot);
        }

        public void Run()
        {
            _boss.TakeOver();
        }
    }
}