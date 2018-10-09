using System;
using System.Collections.Generic;
using System.Text;
using Pipe4Net;

namespace ToyRobot.src.Logger
{
    public class Logger : Ilogger
    {
        public void ShowRobot()
        {
            Console.Write(@"
                            (\    |@@|
                          (__/\__ \--/ __
                             \___|----|  |   __
                                 \ }{ /\ )_ / _\
                                 /\__/\ \__O (__
                                (--/\--)    \__/
                                _)(  )(_
                               `---''---`");

        }

        public void Log(string message)
        {
            Console.Write(message);
        }

        public void EmptyLine()
        {
            Console.Write(Environment.NewLine);
        }

        public void EmptyLines(int value)
        {
            value.GenerateForLoop(EmptyLine);
        }

        public void Arrow()
        {
            Console.Write(@">>------> ");
        }

        public void ShowTable()
        {
            Console.WriteLine(
                @"
                  |¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯|
                  |      |      |      |      |     |
                  |______|______|______|______|_____|
                  |      |      |      |      |     |
                  |      |      |      |      |     |
                  |______|______|______|______|_____|
                  |      |      |      |      |     |
                  |      |      |      |      |     |
                  |______|______|______|______|_____|
                  |      |      |      |      |     |
                  |      |      |      |      |     |
                  |______|______|______|______|_____|
                  |      |      |      |      |     |
                  |      |      |      |      |     |
                  |______|______|______|______|_____|
                "
                );
        }
    }
}
