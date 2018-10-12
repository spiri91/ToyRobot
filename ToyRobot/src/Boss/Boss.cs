using Pipe4Net;
using System.Diagnostics;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Logger;
using ToyRobot.src.Robot;

namespace ToyRobot.Boss
{
    public class Boss
    {
        private Ilogger logger;
        private Table.Table table;
        private Robot.Robot robot;
        private bool isFirstCommand = true;

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
            logger.Arrow();
            logger.Log(e.ToString());
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

        public Command.Command GiveOrder(Command.Command command)
        {
            command.OrderRobot(robot);

            return command;
        }

        public void TakeOver()
        {
            this.ShowTemplate();
            while (true)
            {
                var commandAsString = logger.ReadCommand();

                CommandParser.Parse(commandAsString)
                    .Pipe(CheckFirstCommand)
                    .Pipe(CheckIfValidOrder)
                    .Pipe(GiveOrder)
                    .PipeWith(NeedsRefresh);
            }
        }

        private void NeedsRefresh(Command.Command cmd)
        {
            if (cmd.MovingStuff() && robot.DidIMoved())
                LawAndOrder();
            else
            {
                logger.EmptyLine();
                logger.Log(Messages.WaitingInstructions);
                logger.EmptyLine();
                logger.Log(Messages.Arrow);
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

        private Command.Command CheckFirstCommand(Command.Command cmd)
        {
            if (isFirstCommand)
            {
                if (cmd is Place)
                {
                    isFirstCommand = false;

                    return cmd;
                }

                logger.Log(Messages.FirstCommand);
                logger.EmptyLine();

                return new ChillOut();
            }

            return cmd;
        }

        private Command.Command CheckIfValidOrder(Command.Command arg)
        {
            if (arg.YouValid())
                return arg;

            logger.Log(Messages.BadCommand);

            return new ChillOut();
        }
    }
}
