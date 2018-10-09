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
            new App().Run();
        }
    }
}


public class App
{
    private readonly Table table;
    private List<Cell> cells;
    private Boss boss;
    private Ilogger logger;

    public App() : this(new Logger())
    {
        
    }

    public App(Ilogger logger)
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
        boss.ShowTemplate();
        while (true)
        {
            var commandAsString = logger.ReadCommand();

            Command.Parse(commandAsString).PipeWith(boss.GiveOrder);
        }
    }

    private void Template()
    {
        logger.Log(Messages.IntroInfo);
        logger.EmptyLines(2);
        logger.ShowRobot();
        this.table.DrawYourself();

        logger.EmptyLines(2);
        logger.Log(Messages.WaintingInstructions);
        logger.EmptyLine();
        logger.Arrow();
    }
}
