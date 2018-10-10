using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Pipe4Net;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.src.Table
{
    public class Table
    {
        public IList<Cell.Cell> Cells { get; private set; }
        private Ilogger _logger;

        public Table(Ilogger logger, IList<Cell.Cell> cells)
        {
            Debug.Assert(cells != null);
            Debug.Assert(logger != null);

            Cells = cells;
            this._logger = logger;
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

        public void SwapCells(Cell.Cell a, Cell.Cell b)
        {

        }
    }
}
