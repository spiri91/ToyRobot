using ToyRobot.src.Logger;

namespace TheTests.Mocks
{
    public class MockedLogger : ILogger
    {
        public string SettedCommand { get; private set; }

        public void Arrow()
        {
        }

        public void Clear()
        {
        }

        public void EmptyLine()
        {
        }

        public void EmptyLines(int value)
        {
        }

        public void Log(string message)
        {
        }

        public string ReadCommand()
        {
            return this.SettedCommand;
        }

        public void ShowRobot()
        {
        }

        public void SetCommand(string command)
        {
            this.SettedCommand = command;
        }
    }
}
