namespace ToyRobot.src.Logger
{
    public interface ILogger
    {
        void ShowRobot();

        void Log(string message);

        void EmptyLine();

        void EmptyLines(int value);

        void Arrow();

        string ReadCommand();

        void Clear();
    }
}
