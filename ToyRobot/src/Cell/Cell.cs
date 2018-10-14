using ToyRobot.misc;

namespace ToyRobot.Cell
{
    public abstract class Cell
    {
        public int Index { get; protected set; }

        public Cell(int index)
        {
            BeforeCreationChecks();

            this.Index = index;
        }

        public virtual string DrawYourselfInTable(string str)
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

        public virtual void BeforeCreationChecks()
        {

        }
    }
}
