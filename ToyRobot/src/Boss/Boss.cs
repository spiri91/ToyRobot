using System.Diagnostics;
using Pipe4Net;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Logger;
using ToyRobot.src.Robot;

namespace ToyRobot.Boss
{
    public class Boss
    {
        private Ilogger logger;
        private src.Table.Table table;
        private src.Robot.Robot robot;

        public Boss(Ilogger logger, src.Table.Table table, src.Robot.Robot robot)
        {
            Debug.Assert(logger != null && table != null && robot != null);

            this.logger = logger;
            this.table = table;
            this.robot = robot;
            this.robot.Complain += HearHim;
        }

        private void HearHim(object sender, MessageEventArgs e)
        {
            logger.EmptyLines(2);
            logger.Arrow();
            logger.Log(e.ToString());
            WaitInstruction();
        }

        public void ShowTemplate()
        {
            logger.Log(Messages.IntroInfo);
            logger.EmptyLines(2);
            logger.ShowRobot();
            logger.EmptyLines(2);

            this.table.DrawYourself();

            WaitInstruction();
        }

        public void WaitInstruction()
        {
            logger.EmptyLines(2);
            logger.Log(Messages.WaitingInstructions);
            logger.EmptyLine();
            logger.Arrow();
        }

        public void GiveOrder(Command.Command command)
        {
            command.OrderRobot(robot);
        }

        public void TakeOver()
        {
            this.ShowTemplate();
            while (true)
            {
                var commandAsString = logger.ReadCommand();

                CommandParser.Parse(commandAsString)
                    .Pipe(CheckIfValidOrder)
                    .PipeWith(GiveOrder);

                robot.DidYouMove().IfTrue(LawAndOrder);
            }
        }

        private void LawAndOrder()
        {
            logger.Clear();
            ReorderCells();
            TakeOver();
        }

        private void ReorderCells()
        {
            table.SwapCells(robot.OldIndex, robot.Index);
        }

        private Command.Command CheckIfValidOrder(Command.Command arg)
        {
            if (arg is BadCommand)
            {
                logger.Log(Messages.BadCommand);

                return new ChillOut();
            }
            
            return arg;
        }
    }
}
