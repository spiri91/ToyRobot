using System;

namespace ToyRobot.misc
{
    public class PointsTo
    {
        public Cardinal cardinal { get; private set; }

        public PointsTo(Cardinal cardinal)
        {
            this.cardinal = cardinal;
        }

        internal PointsTo GetLeftDirection()
        {
            var newCardinal = this.cardinal - 1;

            return new PointsTo(newCardinal);
        }

        internal PointsTo GetRightDirection()
        {
            var newCardinal = this.cardinal + 1;

            return new PointsTo(newCardinal);
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(Cardinal), cardinal);
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
