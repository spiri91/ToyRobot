using System.Diagnostics;
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
            this.table.DrawYourself();

            logger.EmptyLines(2);
            logger.Log(Messages.WaintingInstructions);
            logger.EmptyLine();
            logger.Arrow();
        }

        public void GiveOrder(Command.Command command)
        {
            
        }
    }
}
