using System;
using ToyRobot.misc;

namespace ToyRobot.src.Robot
{
    public class Robot : Cell.Cell
    {
        public PointsTo direction { get; private set; }

        public override string DrawYourself(string str)
        {
            var toReplace = "{" + Index + "}";
            var replaceWith = Index > 9 ? Messages.CellRobot + " " : Messages.CellRobot;

            str = str.Replace(toReplace, replaceWith);

            return str;
        }

        public void ChangeDirection(PointsTo pointsTo)
        {
            this.direction = pointsTo;
        }

        public void ChangeXIndex(int xIndex)
        {
            this.XIndex = xIndex;
        }

        public void ChangeYIndex(int yIndex)
        {
            this.YIndex = yIndex;
        }

        internal void GoLeft()
        {
            var newDirection = direction.GetLeftDirection();

            direction = newDirection;
        }

        internal void GoRight()
        {
            var newDirection = direction.GetRightDirection();

            direction = newDirection;
        }

        internal void Shout()
        {
            throw new NotImplementedException();
        }

        internal void Curse()
        {
            throw new NotImplementedException();
        }
    }
}
