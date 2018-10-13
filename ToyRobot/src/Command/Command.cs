using Pipe4Net;
using System;
using System.Collections.Generic;
using ToyRobot.misc;

namespace ToyRobot.Command
{
    public abstract class Command
    {
        public Command()
        {
            SetActionOnRobot();
        }

        protected Action<Robot.Robot> action;

        public abstract bool MovingStuff();

        public virtual bool YouValid() => true;
       
        protected virtual void CheckIfNoRobotAvailable(Robot.Robot robot)
        {
            (robot == null).IfTrue(() => throw new Exception("Missing robot"));
        }

        public void OrderRobot(Robot.Robot robot)
        {
            CheckIfNoRobotAvailable(robot);

            action(robot);
        }

        public abstract void SetActionOnRobot();
    }

    public abstract class MutableCommand : Command
    {
        public override bool MovingStuff() => true;
    }

    public abstract class ImutableCommand : Command
    {
        public override bool MovingStuff() => false;
    }

    public class PlaceCommand : MutableCommand
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public PointsTo PointingTo { get; private set; }

        public PlaceCommand(PointsTo pointsTo, int xPosition, int yPosition)
        {
            (pointsTo == null).IfTrue(() => throw new System.Exception("Bad Arguments"));

            PointingTo = pointsTo;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public override void SetActionOnRobot()
        {
            this.action = (robot) => robot.ChangeCoords(XPosition, YPosition, PointingTo);
        }
    }

    public class GoLeftCommand : ImutableCommand
    {
        public override void SetActionOnRobot()
        {
            this.action = robot => robot.GoLeft();
        }
    }

    public class GoRightCommand : ImutableCommand
    {
        public override void SetActionOnRobot()
        {
           this.action = robot => robot.GoRight();
        }
    }

    public class ReportCommand : ImutableCommand
    {
        public override void SetActionOnRobot()
        {
           this.action = robot => robot.Shout();
        }
    }

    public class MoveCommand : MutableCommand
    {
        public override void SetActionOnRobot()
        {
           this.action = robot => robot.Move();
        }
    }

    public class BadCommand : ImutableCommand
    {
        public override void SetActionOnRobot()
        {
           this.action = robot => robot.Curse();
        }

        public override bool YouValid() => false;
    }

    public class ChillOutCommand : ImutableCommand
    {
        public override void SetActionOnRobot()
        {
           this.action = robot => robot.Chill();
        }
    }

    public static class CommandParser
    {
        public static Command Parse(string commandAsString)
        {
            var arguments = commandAsString.Split(' ');
            arguments = RemoveEmtpyCommands(arguments);

            if (false == ArgsAreValid(arguments)) return new BadCommand();

            if (arguments.Length == 4)
                return ParsePlaceCommand(arguments);

            return ParseMoveCommand(arguments[0]);
        }

        private static string[] RemoveEmtpyCommands(string[] arguments)
        {
            var result = new List<string>();

            arguments.ForEach(x =>
            {
                if (string.IsNullOrWhiteSpace(x)) return;

                result.Add(x.Trim().ToLower());
            });

            return result.ToArray();
        }

        private static Command ParseMoveCommand(string argument)
        {
            argument = argument;

            switch (argument)
            {
                case "move": case "m": return new MoveCommand();
                case "right": case "r": return new GoRightCommand();
                case "left": case "l": return new GoLeftCommand();
                case "report": case "re": return new ReportCommand();

                default: return new ChillOutCommand();
            }
        }

        private static Command ParsePlaceCommand(string[] arguments)
        {
            Cardinal cardinal = GetCardinal(arguments[3]);

            return new PlaceCommand(new PointsTo(cardinal), 
                int.Parse(arguments[1]),
                int.Parse(arguments[2]));
        }

        private static Cardinal GetCardinal(string toLower)
        {
            switch (toLower)
            {
                case "e": return Cardinal.Est;
                case "n": return Cardinal.North;
                case "w": return Cardinal.West;
                case "s": return Cardinal.South; 

                default: return Cardinal.Nowhere;
            }
        }

        private static bool ArgsAreValid(string[] arguments)
        {
            if (arguments.Length > 4) return false;
            if (arguments.Length > 1 && arguments.Length < 4) return false;
            if (arguments.Length == 0) return false;

            if (arguments.Length == 4)
            {
                if (false == int.TryParse(arguments[1], out int _)) return false;
                if (false == int.TryParse(arguments[2], out int _)) return false;

                if (false == IsValidCardinalPoint(arguments[3])) return false;
            }

            var listOfValidCommands = new List<string>
            {
                "place",
                "p",
                "move",
                "m",
                "left",
                "l",
                "right",
                "r",
                "report",
                "re"
            };

            if (listOfValidCommands.IndexOf(arguments[0]) == -1) return false;

            return true;
        }

        private static bool IsValidCardinalPoint(string s)
        {
            var validCardinals = new List<string> {"s", "w", "n", "e"};

            if (validCardinals.IndexOf(s) == -1) return false;

            return true;
        }
    }
}