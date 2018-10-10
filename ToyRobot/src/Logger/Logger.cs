using System;
using Pipe4Net;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.Logger
{
    public class Logger : Ilogger
    {
        public void ShowRobot()
        {
            this.Log(Messages.Robot);

        }

        public void Log(string message)
        {
            Console.Write(message);
        }

        public void EmptyLine()
        {
            this.Log(Environment.NewLine);
        }

        public void EmptyLines(int value)
        {
            value.GenerateForLoop(EmptyLine);
        }

        public void Arrow()
        {
            this.Log(Messages.Arrow);
        }

        public string ReadCommand()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
