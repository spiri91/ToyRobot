using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.src.Cell
{
    public abstract class Cell
    {
        private static int _index = 0;

        protected Cell()
        {
            _index++;

            this.Index = _index;
        }

        public int Index { get; protected set; }

        public int XIndex { get; protected set; }

        public int YIndex { get; protected set; }

        public virtual string DrawYourself(string str)
        {
            var toReplace = "{" + Index + "}";
            var replaceWith = toReplace.toSpaces();

            str = str.Replace(toReplace, replaceWith);

            return str;
        }

        public void SetIndex(int index)
        {
            this.Index = index;
        }
    }
}
