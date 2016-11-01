using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4
{
    public class Utils
    {
        public static void CalculateAvarageCPUCyclesPerSolution(long solutionCount, ref Stopwatch total, ref long validationCount)
        {
            Debug.WriteLine("Total Clock Cycles for solution number " + solutionCount + ": " + total.ElapsedTicks);
            Debug.WriteLine("Average Clock Cycles per validation: " + total.ElapsedTicks / validationCount);
            Debug.WriteLine("Total number of validations: " + validationCount);
            total.Restart();
            validationCount = 0;
        }

        public static void PrintSolutionToConsole(long solutionCount, Dictionary<Enumerations.RowNumber, string> solution)
        {
            Console.WriteLine();
            Console.WriteLine("Solution number " + solutionCount + ": ");
            Console.WriteLine(solution[Enumerations.RowNumber.One]);
            Console.WriteLine(solution[Enumerations.RowNumber.Two]);
            Console.WriteLine(solution[Enumerations.RowNumber.Three]);
            Console.WriteLine(solution[Enumerations.RowNumber.Four]);
            Console.WriteLine(solution[Enumerations.RowNumber.Five]);
            Console.WriteLine(solution[Enumerations.RowNumber.Six]);
            Console.WriteLine(solution[Enumerations.RowNumber.Seven]);
            Console.WriteLine(solution[Enumerations.RowNumber.Eight]);
            Console.WriteLine(solution[Enumerations.RowNumber.Nine]);
        }

        public static void AddSolutionToDataSet(ref DataTable permutationTable, Dictionary<Enumerations.RowNumber, string> solution)
        {
            permutationTable.Rows.Add(solution[Enumerations.RowNumber.One] + solution[Enumerations.RowNumber.Two] + solution[Enumerations.RowNumber.Three]
                                            + solution[Enumerations.RowNumber.Four] + solution[Enumerations.RowNumber.Five] + solution[Enumerations.RowNumber.Six]
                                            + solution[Enumerations.RowNumber.Seven] + solution[Enumerations.RowNumber.Eight] + solution[Enumerations.RowNumber.Nine]);
        }

        public static void BulkPassDataSetToSql(DataTable permutationTable)
        {
            if (permutationTable.Rows.Count % 100 == 0) {
                //TODO:: pass data set to sql table;
            }


        }

        public static void BulkPassDataSetToSql(DataTable permutationTable, Stopwatch total)
        {
            if (permutationTable.Rows.Count % 100 == 0) {
                DisplaySolutionsInTimeMessage(permutationTable, total);
                //TODO:: pass data set to sql table;
            }

            
        }

        private static void DisplaySolutionsInTimeMessage(DataTable permutationTable, Stopwatch total)
        {
            Console.WriteLine(permutationTable.Rows.Count + " solutions in " + total.Elapsed.Hours + " hours " + total.Elapsed.Minutes + " minutes " + total.Elapsed.Seconds + " seconds and " + total.Elapsed.Milliseconds + " milliseconds.");
            Console.ReadLine();
        }
    }
}
