using Pipe4Net;
using System;
using System.Diagnostics;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.src.Boss
{
    public class Boss
    {
        private Ilogger logger;
        private Table.Table table;
        private Robot.Robot robot;

        public Boss(Ilogger logger, Table.Table table, Robot.Robot robot)
        {
            Debug.Assert(logger != null && table != null && robot != null);

            this.logger = logger;
            this.table = table;
        }

        public void ShowTemplate()
        {
            logger.Log(Messages.IntroInfo);
            logger.EmptyLines(2);
            logger.ShowRobot();
            logger.EmptyLines(2);
            this.table.DrawYourself();

            logger.EmptyLines(2);
            logger.Log(Messages.WaintingInstructions);
            logger.EmptyLine();
            logger.Arrow();
        }

        public void GiveOrder(Command.Command command)
        {
            
        }

        public void TakeOver()
        {
            this.ShowTemplate();
            while (true)
            {
                var commandAsString = logger.ReadCommand();

                CommandParser.Parse(commandAsString)
                    .Pipe(this.CheckIfValidOrder)
                    .PipeWith(this.GiveOrder);
            }
        }

        private Command.Command CheckIfValidOrder(Command.Command arg)
        {
            return null;
        }
    }
}
