using System;
using Pipe4Net;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.Logger
{
    public class Logger : ILogger
    {
        virtual public void ShowRobot()
        {
            Log(Messages.Robot);
        }

        virtual public void Log(string message)
        {
            Console.Write(message);
        }

        virtual public void EmptyLine()
        {
            Log(Environment.NewLine);
        }

        virtual public void EmptyLines(int value)
        {
            value.GenerateForLoop(EmptyLine);
        }

        virtual public void Arrow()
        {
            Log(Messages.Arrow);
        }

        virtual public string ReadCommand()
        {
            return Console.ReadLine();
        }

        virtual public void Clear()
        {
            Console.Clear();
        }
    }
}
