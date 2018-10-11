using System.Collections.Generic;
using Pipe4Net;
using ToyRobot.Boss;
using ToyRobot.Cell;
using ToyRobot.Logger;
using ToyRobot.Robot;
using ToyRobot.src.Logger;
using ToyRobot.src.Table;

public class Orchestrator
{
    private Boss boss;

    public Orchestrator() : this(new Logger()) { }

    public Orchestrator(Ilogger logger)
    {
        int numberOfCells = 25;
        var cells = new List<Cell>();
        numberOfCells.GenerateForLoop(() => cells.Add(new EmptyCell()));
        var robot = new Robot(x => x <= numberOfCells);
        cells.Add(robot);

        var table = new Table(logger, cells);
        this.boss = new Boss(logger, table, robot);
    }

    public void Run()
    {
        boss.TakeOver();
    }
}