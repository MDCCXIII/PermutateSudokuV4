using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4
{
    public class ValidationAlgorithm0
    {
        Dictionary<Enumerations.RowNumber, string> solution = new Dictionary<Enumerations.RowNumber, string>();
        Stopwatch validationTime = new Stopwatch();

        public bool validateSolution(Dictionary<Enumerations.RowNumber, string> solution)
        {
            this.solution = solution;

            List<string> boxes = new List<string>() { "", "", "", "", "", "", "", "", "" };
            List<string> columns = new List<string>() { "", "", "", "", "", "", "", "", "" };

            Populate(ref boxes, ref columns);

            if (!validateBoxes(boxes) || !ValidateColumns(columns)) {
                return false;
            }
            return true;
        }

        private static bool ValidateColumns(List<string> columns)
        {
            foreach (string column in columns) {
                if (column.Distinct().Count() != column.Length) {
                    return false;
                }
            }
            return true;
        }

        private static bool validateBoxes(List<string> boxes)
        {
            foreach (string box in boxes) {
                if (box.Distinct().Count() != box.Length) {
                    return false;
                }
            }
            return true;
        }

        private void Populate(ref List<string> boxes, ref List<string> columns)
        {
            foreach (Enumerations.RowNumber row in Enum.GetValues(typeof(Enumerations.RowNumber))) {
                PopulateBoxValues(ref boxes, row);
                PopulateColumnValues(ref columns, row);
            }
        }

        private void PopulateBoxValues(ref List<string> boxes, Enumerations.RowNumber row)
        {
            if (!solution[row].Equals("")) {
                switch (row) {
                    case Enumerations.RowNumber.One:
                    case Enumerations.RowNumber.Two:
                    case Enumerations.RowNumber.Three:
                        boxes[0] += solution[row].Substring(0, 3);
                        boxes[1] += solution[row].Substring(3, 3);
                        boxes[2] += solution[row].Substring(6, 3);
                        break;
                    case Enumerations.RowNumber.Four:
                    case Enumerations.RowNumber.Five:
                    case Enumerations.RowNumber.Six:
                        boxes[3] += solution[row].Substring(0, 3);
                        boxes[4] += solution[row].Substring(3, 3);
                        boxes[5] += solution[row].Substring(6, 3);
                        break;
                    case Enumerations.RowNumber.Seven:
                    case Enumerations.RowNumber.Eight:
                    case Enumerations.RowNumber.Nine:
                        boxes[6] += solution[row].Substring(0, 3);
                        boxes[7] += solution[row].Substring(3, 3);
                        boxes[8] += solution[row].Substring(6, 3);
                        break;
                }
            }
        }

        private void PopulateColumnValues(ref List<string> columns, Enumerations.RowNumber row)
        {
            if (!solution[row].Equals("")) {
                Char[] value = solution[row].ToArray();
                columns[0] += value[0];
                columns[1] += value[1];
                columns[2] += value[2];
                columns[3] += value[3];
                columns[4] += value[4];
                columns[5] += value[5];
                columns[6] += value[6];
                columns[7] += value[7];
                columns[8] += value[8];
            }
        }
    }
}
