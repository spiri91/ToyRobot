using System;
using ToyRobot.misc;
using ToyRobot.src.Logger;

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

    public App() : this(new Logger())
    {
            
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
        logger.EmptyLines(4);
        logger.ShowTable();
        logger.EmptyLines(3);
        logger.Arrow();
    }
}
