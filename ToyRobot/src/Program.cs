using System;
using System.Collections.Generic;
using Pipe4Net;
using ToyRobot.misc;
using ToyRobot.src.Cell;
using ToyRobot.src.Logger;
using ToyRobot.src.Table;

namespace ToyRobot
{
    class Program
    {
        private readonly Ilogger logger;

        static void Main()
        {
            new App().Run();

            Console.ReadKey();
        }
    }
}


public class App
{
    private readonly Ilogger logger;
    private readonly Table table;
    private List<Cell> cells;

    public App() : this(new Logger())
    {
        cells = new List<Cell>();

        25.GenerateForLoop(() => cells.Add(new EmptyCell()));

        this.table = new Table(logger, cells);
    }

    public App(Ilogger logger)
    {
        this.logger = logger;
    }

    public void Run()
    {
        logger.Log(Messages.IntroInfo);
        logger.EmptyLines(2);
        logger.ShowRobot();
        this.table.DrawYourself();

    }
}
