using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.misc;

namespace ToyRobot.Robot
{
    public class Robot : Cell.Cell
    {
        private IList<int> LastPositons;

        public int OldIndex => LastPositons.Last();

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }

        public PointsTo Direction { get; private set; }

        public event EventHandler<StringEventsArgs> Complain;

        public Func<int, int, bool> IsValidMove;

        public Func<int, int, int> CalculateIndex { get; set; }

        private bool IMoved;

        public Robot(Func<int, int, bool> validMove, Func<int, int, int> calculateIndex)
        {
            this.LastPositons = new List<int>();
            this.IsValidMove = validMove;
            this.CalculateIndex = calculateIndex;
        }

        public override string DrawYourself(string str)
        {
            var toReplace = "{" + Index + "}";
            var replaceWith = Index > 9 ? Messages.CellRobot + " " : Messages.CellRobot;

            str = str.Replace(toReplace, replaceWith);

            return str;
        }

        public override bool YouEmpty() => false;

        public void GoToIndex()
        {
            var newIndex = CalculateIndex(XIndex, YIndex);

            this.LastPositons.Add(Index);
            this.Index = newIndex;
            this.IMoved = true;
        }

        private bool Valid(int xIndex, int yIndex)
        {
            return this.IsValidMove(xIndex, yIndex);
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
            int _xIndex = XIndex;
            int _yIndex = YIndex;

            switch (this.Direction.cardinal)
            {
                case Cardinal.Est:
                    _xIndex = this.XIndex + 1;
                    break;

                case Cardinal.North:
                    _yIndex = this.YIndex + 1;
                    break;

                case Cardinal.South:
                    _yIndex = this.YIndex - 1;
                    break;

                case Cardinal.West:
                    _xIndex = this.XIndex - 1;
                    break;
            }

            if (Valid(_xIndex, _yIndex))
            {
                this.XIndex = _xIndex;
                this.YIndex = _yIndex;

                GoToIndex();
            }
            else BadMove();

        }

        private void BadMove()
        {
            this.IMoved = false;
            this.Curse();
        }

        public bool DidIMoved() => IMoved;

        public void Chill() { }

        public void ChangeCoords(int xPosition, int yPosition, PointsTo pointingTo)
        {
            if (Valid(xPosition, yPosition))
            {
                this.XIndex = xPosition;
                this.YIndex = yPosition;
                this.Direction = pointingTo;

                GoToIndex();
            }
            else BadMove();
        }
    }
}
