using System;

namespace ToyRobot.misc
{
    public class StringEventsArgs : EventArgs
    {
        public string Value { get; private set; }

        public StringEventsArgs(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
