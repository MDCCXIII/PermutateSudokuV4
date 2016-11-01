using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4
{
    class ValidationAlgorithm1
    {
        Dictionary<Enumerations.RowNumber, string> solution = new Dictionary<Enumerations.RowNumber, string>();

        public bool validateSolution(ref Dictionary<Enumerations.RowNumber, string> solution, int rowNumber, string row)
        {

            this.solution = solution;
            if (ValidateBoxValues(row, rowNumber) && ValidateColumnValues(row)) {
                solution[(Enumerations.RowNumber)rowNumber] = row;
                return true;
            }
            return false;
        }

        private bool ValidateColumnValues(string value)
        {
            char[] rowIndices = value.ToArray();
            foreach (string row in solution.Values) {
                if (!row.Equals("")) {
                    for (int i = 0; i < 9; i++) {
                        if (row.ToArray()[i].Equals(rowIndices[i])) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidateBoxValues(string value, int rowNumber)
        {
            char[] rowIndices = value.ToArray();
            int[] rowsTocheck = null;

            rowsTocheck = GetRowsToCheck(rowNumber, rowsTocheck);

            for (int i = 0; i < 9; i++) {
                foreach (int row in rowsTocheck) {
                    if (!solution[(Enumerations.RowNumber)row].Equals("")) {
                        switch (i) {
                            case 0:
                            case 1:
                            case 2:
                                if (solution[(Enumerations.RowNumber)row].Substring(0, 3).Contains(rowIndices[i].ToString())) {
                                    return false;
                                }
                                break;
                            case 3:
                            case 4:
                            case 5:
                                if (solution[(Enumerations.RowNumber)row].Substring(3, 3).Contains(rowIndices[i].ToString())) {
                                    return false;
                                }
                                break;
                            case 6:
                            case 7:
                            case 8:
                                if (solution[(Enumerations.RowNumber)row].Substring(6, 3).Contains(rowIndices[i].ToString())) {
                                    return false;
                                }
                                break;
                        }
                    }
                }
            }
            return true;
        }

        private static int[] GetRowsToCheck(int rowNumber, int[] rowsTocheck)
        {
            if (rowNumber > 0 && rowNumber < 4) rowsTocheck = new int[] { 1, 2, 3 };
            else if (rowNumber > 3 && rowNumber < 7) rowsTocheck = new int[] { 4, 5, 6 };
            else if (rowNumber > 6 && rowNumber < 10) rowsTocheck = new int[] { 7, 8, 9 };
            return rowsTocheck;
        }
    }
}
