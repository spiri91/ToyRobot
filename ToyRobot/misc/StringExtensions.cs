using Pipe4Net;

namespace ToyRobot.misc
{
    public static class StringExtensions
    {
        public static string ToSpaces(this string value)
        {
            var length = value.Length;
            var toReturn = "";

            length.GenerateForLoop(() => toReturn += " ");

            return toReturn;
        }
    }
}
