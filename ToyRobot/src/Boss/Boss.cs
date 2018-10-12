using System.Diagnostics;
using Pipe4Net;
using ToyRobot.Command;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.Boss
{
    public class Boss
    {
        private ILogger _logger;
        private Table.Table _table;
        private Robot.Robot _robot;
        private bool _isFirstCommand = true;

        public Boss(ILogger logger, Table.Table table, Robot.Robot robot)
        {
            Debug.Assert(logger != null && table != null && robot != null);

            _logger = logger;
            _table = table;
            _robot = robot;
            _robot.Complain += HearHim;
        }

        private void HearHim(object sender, StringEventsArgs e)
        {
            _logger.Arrow();
            _logger.Log(e.ToString());
        }

        public void ShowTemplate()
        {
            _logger.Log(Messages.IntroInfo);
            _logger.Log(Messages.Commands);
            _logger.EmptyLines(2);
            _logger.ShowRobot();
            _logger.EmptyLines(2);

            _table.DrawYourself();

            WaitInstruction();
        }

        public void WaitInstruction()
        {
            _logger.EmptyLines(2);
            _logger.Log(Messages.WaitingInstructions);
            _logger.EmptyLine();
            _logger.Arrow();
        }

        public Command.Command GiveOrder(Command.Command command)
        {
            command.OrderRobot(_robot);

            return command;
        }

        public void TakeOver()
        {
            ShowTemplate();
            while (true)
            {
                var commandAsString = _logger.ReadCommand();

                CommandParser.Parse(commandAsString)
                    .Pipe(CheckFirstCommand)
                    .Pipe(CheckIfValidOrder)
                    .Pipe(GiveOrder)
                    .PipeWith(NeedsRefresh);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void NeedsRefresh(Command.Command cmd)
        {
            (cmd.MovingStuff() && _robot.DidIMoved())
                .IfTrue(LawAndOrder)
                .Else(() =>
                {
                    _logger.EmptyLine();
                    _logger.Log(Messages.WaitingInstructions);
                    _logger.EmptyLine();
                    _logger.Log(Messages.Arrow);
                });
        }

        private void LawAndOrder()
        {
            _logger.Clear();
            ReorderCells();
            TakeOver();
        }

        private void ReorderCells()
        {
            _table.SwapCells(_robot.OldIndex, _robot.Index);
        }

        private Command.Command CheckFirstCommand(Command.Command cmd)
        {
            if (_isFirstCommand)
            {
                if (cmd is Place)
                {
                    _isFirstCommand = false;

                    return cmd;
                }

                _logger.Log(Messages.FirstCommand);
                _logger.EmptyLine();

                return new ChillOut();
            }

            return cmd;
        }

        private Command.Command CheckIfValidOrder(Command.Command arg)
        {
            if (arg.YouValid())
                return arg;

            _logger.Log(Messages.BadCommand);

            return new ChillOut();
        }
    }
}
