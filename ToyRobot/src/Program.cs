using System;
using System.Collections.Generic;
using System.Data;
using Pipe4Net;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Boss;
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
    private readonly Table table;
    private List<Cell> cells;
    private Boss boss;
    private Ilogger logger;

    public Orchestrator() : this(new Logger())
    {
        
    }

    public Orchestrator(Ilogger logger)
    {
        this.logger = logger;
        cells = new List<Cell>();
        var robot = new Robot();
        24.GenerateForLoop(() => cells.Add(new EmptyCell()));
        cells.Add(robot);

        this.table = new Table(logger, cells);
        this.boss = new Boss(logger, table, robot);
    }

    public void Run()
    {
        boss.TakeOver();
    }
}
