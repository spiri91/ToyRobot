using System;

namespace ToyRobot.misc
{
    public class PointsTo
    {
        public Cardinal Cardinal { get; private set; }

        public PointsTo(Cardinal cardinal)
        {
            Cardinal = cardinal;
        }

        public PointsTo GetLeftDirection()
        {
            Cardinal newCardinal;

            switch (Cardinal)
            {
                case Cardinal.North:
                    newCardinal = Cardinal.West;
                    break;
                case Cardinal.West:
                    newCardinal = Cardinal.South;
                    break;
                case Cardinal.South:
                    newCardinal = Cardinal.Est;
                    break;
                case Cardinal.Est:
                    newCardinal = Cardinal.North;
                    break;

                default:
                    newCardinal = Cardinal.Nowhere;
                    break;
            }

            return new PointsTo(newCardinal);
        }

        public PointsTo GetRightDirection()
        {
            Cardinal newCardinal;

            switch (Cardinal)
            {
                case Cardinal.North:
                    newCardinal = Cardinal.Est;
                    break;
                case Cardinal.West:
                    newCardinal = Cardinal.North;
                    break;
                case Cardinal.South:
                    newCardinal = Cardinal.West;
                    break;
                case Cardinal.Est:
                    newCardinal = Cardinal.South;
                    break;

                default:
                    newCardinal = Cardinal.Nowhere;
                    break;
            }

            return new PointsTo(newCardinal);
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(Cardinal), Cardinal);
        }
    }

    public enum Cardinal
    {
        North = 1,
        South = 3,
        Est = 2,
        West = 4,
        Nowhere = 0
    }
}
