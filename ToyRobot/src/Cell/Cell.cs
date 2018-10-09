using ToyRobot.src.Logger;

namespace ToyRobot.src.Cell
{
    public abstract class Cell
    {
        public int Index { get; protected set; }

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }
    }
}
