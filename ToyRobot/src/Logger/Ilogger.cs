using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.src.Logger
{
    public interface Ilogger
    {
        void ShowRobot();

        void Log(string message);

        void EmptyLine();

        void EmptyLines(int value);

        void Arrow();

        void ShowTable();
    }
}
