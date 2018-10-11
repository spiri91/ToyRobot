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
            throw new NotImplementedException();
        }

        internal PointsTo GetRightDirection()
        {
            throw new NotImplementedException();
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
