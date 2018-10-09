using System;
using System.Collections.Generic;
using System.Text;
using Pipe4Net;
using ToyRobot.misc;

namespace ToyRobot.src.Logger
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
    }
}
