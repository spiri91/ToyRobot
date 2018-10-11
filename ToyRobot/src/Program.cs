using System;
using System.Collections.Generic;
using System.Data;
using Pipe4Net;
using ToyRobot.Boss;
using ToyRobot.Command;
using ToyRobot.Logger;
using ToyRobot.misc;
using ToyRobot.src.Cell;
using ToyRobot.src.Logger;
using ToyRobot.src.Robot;
using ToyRobot.src.Table;

namespace ToyRobot
{
    class Program
    {
        private readonly Ilogger logger;

        static void Main()
        {
            new Orchestrator().Run();
        }
    }
}

public class Orchestrator
{
    private Boss boss;

    public Orchestrator() : this(new Logger()) { }

    public Orchestrator(Ilogger logger)
    {
        int numberOfCells = 25;
        var cells = new List<Cell>();
        var robot = new Robot(x => x <= numberOfCells);
        numberOfCells.GenerateForLoop(() => cells.Add(new EmptyCell()));

        cells.Add(robot);

        var table = new Table(logger, cells);
        this.boss = new Boss(logger, table, robot);
    }

    public void Run()
    {
        boss.TakeOver();
    }
}
