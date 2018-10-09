using ToyRobot.misc;

namespace ToyRobot.src.Robot
{
    public class Robot : Cell.Cell
    {
        public override string DrawYourself(string str)
        {
            var toReplace = "{" + Index + "}";
            var replaceWith = Index > 9 ? Messages.CellRobot + " " : Messages.Robot;

            str = str.Replace(toReplace, replaceWith);

            return str;
        }
    }
}
