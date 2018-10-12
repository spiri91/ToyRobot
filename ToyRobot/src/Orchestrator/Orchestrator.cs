using System;
using System.Collections.Generic;
using Pipe4Net;
using ToyRobot.Boss;
using ToyRobot.Cell;
using ToyRobot.Logger;
using ToyRobot.Robot;
using ToyRobot.src.Logger;
using ToyRobot.Table;

public class Orchestrator
{
    private Boss boss;

    private static int numberOfCells = 25;
    private static int rowAndColumMaxIndex = 5;

    public Orchestrator() : this(new Logger()) { }

    private static Func<int, int, bool> validMove = (xIndex, yIndex) =>
    {
        var newIndex = calculateIndex(xIndex, yIndex);

        if (newIndex > numberOfCells) return false;

        if (xIndex > 5 || xIndex < 1) return false;

        if (yIndex > 5 || yIndex < 1) return false;

        return true;
    };

    private static Func<int, int, int> calculateIndex = (xIndex, yIndex) =>
    {
        var newIndex = xIndex + 5 * (yIndex - 1);

        return newIndex;
    };

    public Orchestrator(Ilogger logger)
    {

        var cells = new List<Cell>();
        numberOfCells.GenerateForLoop(() => cells.Add(new EmptyCell()));


        var robot = new Robot(validMove, calculateIndex);
        cells.Add(robot);

        var table = new Table(logger, cells);
        this.boss = new Boss(logger, table, robot);
    }

    public void Run()
    {
        boss.TakeOver();
    }
}