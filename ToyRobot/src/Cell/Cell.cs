using ToyRobot.misc;

namespace ToyRobot.Cell
{
    public abstract class Cell
    {
        private static int _index;

        public Cell()
        {
            _index++;

            Index = _index;
        }

        public int Index { get; protected set; }

        public virtual string DrawYourself(string str)
        {
            str = str ?? string.Empty;

            var toReplace = "{" + Index + "}";
            var replaceWith = toReplace.ToSpaces();

            str = str.Replace(toReplace, replaceWith);

            return str;
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public abstract bool YouEmpty();
    }
}
