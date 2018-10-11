using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.src.Robot;

namespace ToyRobot.misc
{
    public class StringEventsArgs : MessageEventArgs
    {
        public string value { get; private set; }

        public StringEventsArgs(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
