using System;
using ToyRobot.misc;
using ToyRobot.src.Robot;

namespace ToyRobot.Command
{
    public abstract class Command
    {
        public abstract void OrderRobot(Robot robot);
    }

    public class Place : Command
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public PointsTo PointingTo { get; private set; }

        public Place(PointsTo pointsTo, int xPosition, int yPosition)
        {
            this.PointingTo = pointsTo;
            this.XPosition = xPosition;
            this.YPosition = xPosition;
        }

        public override void OrderRobot(Robot robot)
        {
            robot.ChangeDirection(this.PointingTo);
            robot.ChangeXIndex(this.XPosition);
            robot.ChangeYIndex(this.YPosition);
        }
    }

    public class GoLeft : Command
    {
        public override void OrderRobot(Robot robot)
        {
            robot.GoLeft();
        }
    }

    public class GoRight : Command
    {
        public override void OrderRobot(Robot robot)
        {
            robot.GoRight();
        }
    }

    public class Report : Command
    {
        public override void OrderRobot(Robot robot)
        {
            robot.Shout();
        }
    }

    public class BadCommand : Command
    {
        public override void OrderRobot(Robot robot)
        {
            robot.Curse();
        }
    }

    public static class CommandParser
    {
        public static Command Parse(string commandAsString)
        {
            return null;
        }
    }
}