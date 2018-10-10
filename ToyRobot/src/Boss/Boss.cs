using Pipe4Net;
using System.Diagnostics;
using System.Linq;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Cell;
using ToyRobot.src.Logger;
using ToyRobot.src.Robot;

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
            var robotOldIndex = robot.OldIndex;
            var tableCellWithRobotIndex = table.Cells.Where(c => c is EmptyCell).Single(x => x.Index == robot.Index);

            tableCellWithRobotIndex.SetIndex(robotOldIndex);
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
