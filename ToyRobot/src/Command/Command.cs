namespace ToyRobot.Command
{
    public sealed class Command
    {
        private Command() { }

        public static Command Parse(string commandAsString)
        {
            return new Command();
        }
    }
}