using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.misc;

namespace ToyRobot.Robot
{
    public class Robot : Cell.Cell
    {
        private IList<int> _lastPositons;

        public int OldIndex => _lastPositons.Last();

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }

        public PointsTo Direction { get; private set; }

        public event EventHandler<StringEventsArgs> Complain;

        public Func<int, int, bool> IsValidMove;

        public Func<int, int, int> CalculateIndex { get; set; }

        private bool _moved;

        public Robot(Func<int, int, bool> validMove, Func<int, int, int> calculateIndex)
        {
            _lastPositons = new List<int>();
            IsValidMove = validMove;
            CalculateIndex = calculateIndex;
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

            _lastPositons.Add(Index);
            Index = newIndex;
            _moved = true;
        }

        private bool Valid(int xIndex, int yIndex)
        {
            return IsValidMove(xIndex, yIndex);
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
            int xIndex = XIndex;
            int yIndex = YIndex;

            switch (Direction.Cardinal)
            {
                case Cardinal.Est:
                    xIndex = XIndex + 1;
                    break;

                case Cardinal.North:
                    yIndex = YIndex + 1;
                    break;

                case Cardinal.South:
                    yIndex = YIndex - 1;
                    break;

                case Cardinal.West:
                    xIndex = XIndex - 1;
                    break;
            }

            if (Valid(xIndex, yIndex))
            {
                XIndex = xIndex;
                YIndex = yIndex;

                GoToIndex();
            }
            else BadMove();

        }

        private void BadMove()
        {
            _moved = false;
            Curse();
        }

        public bool DidIMoved() => _moved;

        public void Chill() { }

        public void ChangeCoords(int xPosition, int yPosition, PointsTo pointingTo)
        {
            if (Valid(xPosition, yPosition))
            {
                XIndex = xPosition;
                YIndex = yPosition;
                Direction = pointingTo;

                GoToIndex();
            }
            else BadMove();
        }
    }
}
