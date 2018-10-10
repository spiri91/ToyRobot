using System;
using ToyRobot.misc;

namespace ToyRobot.src.Robot
{
    public class Robot : Cell.Cell
    {
        public int OldIndex { get; set; }

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }

        public PointsTo direction { get; private set; }

        public event EventHandler<MessageEventArgs> Complain;

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

        public void ChangeIndex()
        {
            this.OldIndex = Index;
            this.Index = XIndex + (5 * (YIndex-1));
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

        internal bool DidYouMove()
        {
            return true;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Chill()
        {
            
        }
    }
}
