using Pipe4Net;
using System.Diagnostics;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Logger;
using ToyRobot.src.Robot;
using ToyRobot.src.Table;

namespace ToyRobot.Boss
{
    public class Boss
    {
        private Ilogger logger;
        private Table table;
        private Robot.Robot robot;
        private bool isFirstCommand = true;

        public Boss(Ilogger logger, Table table, Robot.Robot robot)
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
            if(cmd is FizicCommand) 
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
                logger.Log(Messages.WaitingInstructions);
                logger.EmptyLine();
                logger.Log(Messages.Arrow);

                return new ChillOut();
            }

            return cmd;
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
