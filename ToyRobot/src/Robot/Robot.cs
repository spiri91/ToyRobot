using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.misc;
using ToyRobot.src.Robot;

namespace ToyRobot.Robot
{
    public class Robot : Cell.Cell
    {
        private IList<int> LastPositons;

        public int OldIndex => LastPositons.Last();

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }

        public PointsTo Direction { get; private set; }

        public event EventHandler<MessageEventArgs> Complain;

        public Func<int, bool> IsValidMove;

        public Robot() : this(x => true) { }

        public Robot(Func<int, bool> validMove)
        {
            this.LastPositons = new List<int>();
            this.IsValidMove = validMove;
        }

        public override string DrawYourself(string str)
        {
            var toReplace = "{" + Index + "}";
            var replaceWith = Index > 9 ? Messages.CellRobot + " " : Messages.CellRobot;

            str = str.Replace(toReplace, replaceWith);

            return str;
        }

        public void ChangeDirection(PointsTo pointsTo)
        {
            this.Direction = pointsTo;
        }

        public void ChangeXIndex(int xIndex)
        {
            this.XIndex = xIndex;
        }

        public void GoToIndex()
        {
            var newIndex = XIndex + (5 * (YIndex - 1));

            if (this.IsValidMove(newIndex))
            {
                this.LastPositons.Add(Index);
                this.Index = newIndex;
            }
            else
                this.Curse();
        }

        public void ChangeYIndex(int yIndex)
        {
            this.YIndex = yIndex;
        }

        internal void GoLeft()
        {
            var newDirection = Direction.GetLeftDirection();

            Direction = newDirection;
        }

        internal void GoRight()
        {
            var newDirection = Direction.GetRightDirection();

            Direction = newDirection;
        }

        internal void Shout()
        {
            Complain?.Invoke(this, new StringEventsArgs($"x: {XIndex}\t y: {YIndex}\t p:{Direction}"));
        }

        internal void Curse()
        {
            Complain?.Invoke(this, new StringEventsArgs(Messages.BabyCrying));
        }

        public void Move()
        {
            switch (this.Direction.cardinal)
            {
                case Cardinal.Est:
                    this.ChangeXIndex(this.XIndex + 1);
                    this.GoToIndex();
                    break;

                case Cardinal.North:
                    this.ChangeYIndex(this.YIndex - 1);
                    this.GoToIndex();
                    break;

                case Cardinal.South:
                    this.ChangeYIndex(this.YIndex + 1);
                    this.GoToIndex();
                    break;

                case Cardinal.West:
                    this.ChangeXIndex(this.XIndex - 1);
                    this.GoToIndex();
                    break;
            }
        }

        public void Chill() { }
    }
}
