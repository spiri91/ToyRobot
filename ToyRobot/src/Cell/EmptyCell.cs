namespace ToyRobot.Cell
{
    public class EmptyCell : Cell
    {
        public EmptyCell(int index) : base(index) { }

        public override bool YouEmpty() => true;
    }
}
