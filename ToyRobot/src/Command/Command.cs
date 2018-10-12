﻿using System.Collections.Generic;
using ToyRobot.misc;

namespace ToyRobot.Command
{
    public abstract class Command
    {
        public abstract bool MovingStuff();

        public virtual bool YouValid() => true;
       
        public abstract void OrderRobot(Robot.Robot robot);
    }

    public abstract class MutableCommand : Command
    {
        public override bool MovingStuff() => true;
    }

    public abstract class ImutableCommand : Command
    {
        public override bool MovingStuff() => false;
    }

    public class Place : MutableCommand
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public PointsTo PointingTo { get; private set; }

        public Place(PointsTo pointsTo, int xPosition, int yPosition)
        {
            PointingTo = pointsTo;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public override void OrderRobot(Robot.Robot robot)
        {
            robot.ChangeCoords(XPosition, YPosition, PointingTo);
        }
    }

    public class GoLeft : ImutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.GoLeft();
        }
    }

    public class GoRight : ImutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.GoRight();
        }
    }

    public class Report : ImutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.Shout();
        }
    }

    public class Move : MutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.Move();
        }
    }

    public class BadCommand : ImutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.Curse();
        }

        public override bool YouValid() => false;
    }

    public class ChillOut : ImutableCommand
    {
        public override void OrderRobot(Robot.Robot robot)
        {
            robot.Chill();
        }
    }

    public static class CommandParser
    {
        public static Command Parse(string commandAsString)
        {
            var arguments = commandAsString.Split(' ');

            if (false == ArgsAreValid(arguments)) return new BadCommand();

            if (arguments.Length == 4)
                return ParsePlaceCommand(arguments);

            return ParseMoveCommand(arguments[0]);
        }

        private static Command ParseMoveCommand(string argument)
        {
            argument = argument.Trim().ToLower();

            switch (argument)
            {
                case "move": case "m": return new Move();
                case "right": case "r": return new GoRight();
                case "left": case "l": return new GoLeft();
                case "report": case "re": return new Report();

                default: return new ChillOut();
            }
        }

        private static Command ParsePlaceCommand(string[] arguments)
        {
            Cardinal cardinal = GetCardinal(arguments[3].Trim().ToLower());

            return new Place(new PointsTo(cardinal), 
                int.Parse(arguments[1].Trim()),
                int.Parse(arguments[2].Trim()));
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

            if (listOfValidCommands.IndexOf(arguments[0].Trim().ToLower()) == -1) return false;

            return true;
        }

        private static bool IsValidCardinalPoint(string s)
        {
            var validCardinals = new List<string> {"s", "w", "n", "e"};

            if (validCardinals.IndexOf(s.Trim().ToLower()) == -1) return false;

            return true;
        }
    }
}