using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.Table
{
    public class Table
    {
        public IList<Cell.Cell> Cells { get; private set; }
        private ILogger _logger;

        public Table(ILogger logger, IList<Cell.Cell> cells)
        {
            Debug.Assert(cells != null);
            Debug.Assert(logger != null);

            Cells = cells;
            _logger = logger;
        }

        public void DrawYourself()
        {
            var table = Messages.EmptyTable;

            foreach (var cell in Cells)
            {
                table = cell.DrawYourself(table);
            }

            _logger.Log(table);
        }

        public void SwapCells(int oldIndex, int index)
        {
            if (oldIndex == index) return;

            var robotOldIndex = oldIndex;
            var tableCellWithRobotIndex = Cells.Where(c => c.YouEmpty()).Single(x => x.Index == index);

            tableCellWithRobotIndex.SetIndex(robotOldIndex);
        }
    }
}
