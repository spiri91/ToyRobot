using System.Collections.Generic;
using System.Diagnostics;
using Pipe4Net;
using ToyRobot.misc;
using ToyRobot.src.Logger;

namespace ToyRobot.src.Table
{
    public class Table
    {
        private IList<Cell.Cell> Cells;
        private Ilogger _logger;

        public Table(Ilogger loggger, IList<Cell.Cell> cells, Ilogger logger)
        {
            Debug.Assert(cells != null);
            Debug.Assert(loggger != null);

            Cells = cells;
            this._logger = logger;
        }

        public void DrawYourself()
        {


            _logger.Log(Messages.EmptyTable);
        }
    }
}
