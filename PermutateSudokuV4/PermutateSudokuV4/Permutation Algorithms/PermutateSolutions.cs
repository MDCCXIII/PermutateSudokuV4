using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4
{
    class PermutateSolutions
    {

        private void Permutate(int rowIndex)
        {
            //Change this to control the permutation/validation algorithm to use.
            PermutateV1(rowIndex);
        }

        List<string> rows = DAO.GetAIPermutations();

        Dictionary<Enumerations.RowNumber, string> solution = new Dictionary<Enumerations.RowNumber, string>();
        DataTable permutationTable = new DataTable("Permutations");

        Stopwatch total = new Stopwatch();
        Stopwatch permutationTime = new Stopwatch();

        ValidationAlgorithm1 v1 = new ValidationAlgorithm1();
        ValidationAlgorithm0 v0 = new ValidationAlgorithm0();

        long validationCount = 0;
        long solutionCount = 0;

        public PermutateSolutions()
        {
            InitSolution();
            permutationTable.Columns.Add("Permutation", typeof(string));
            total.Start();
            countNumberOfValidSecondRowsV1();
            countNumberOfValidSecondRowsV0();
            //Permutate(2);
        }

        private void countNumberOfValidSecondRowsV1()
        {
            int rowIndex = 2;
            int validRowCount = 0;
            foreach (string row in rows) {
                if (v1.validateSolution(ref solution, rowIndex, row)) {
                    //if (validRowCount < 100) {
                    //    Console.WriteLine(row);
                    //}
                    validRowCount++;
                }
                solution[(Enumerations.RowNumber)rowIndex] = "";
            }
            Console.WriteLine("Number of Valid second rows according to ValidationAlgorithm1: " + validRowCount);

        }

        private void countNumberOfValidSecondRowsV0()
        {
            int rowIndex = 2;
            int validRowCount = 0;
            foreach (string row in rows) {
                solution[(Enumerations.RowNumber)rowIndex] = row;
                if (v0.validateSolution(solution)) {
                    //if (validRowCount < 100) {
                    //    Console.WriteLine(row);
                    //}
                    validRowCount++;
                }
                solution[(Enumerations.RowNumber)rowIndex] = "";
            }
            Console.WriteLine("Number of Valid second rows according to ValidationAlgorithm0: " + validRowCount);

        }

        private void PermutateV1(int rowIndex)
        {
            permutationTime.Start();
            foreach (string row in rows) {
                validationCount++;
                if (v1.validateSolution(ref solution, rowIndex, row)) {
                    if (NextAction(rowIndex)) break;
                }
            }
            solution[(Enumerations.RowNumber)rowIndex] = "";
        }

        private void PermutateV0(int rowIndex)
        {
            permutationTime.Start();
            foreach (string row in rows) {
                validationCount++;
                solution[(Enumerations.RowNumber)rowIndex] = row;
                if (v0.validateSolution(solution)) {
                    if (NextAction(rowIndex)) break;
                }
            }
            solution[(Enumerations.RowNumber)rowIndex] = "";
        }

        private bool NextAction(int rowIndex)
        {
            bool breakLoop = false;

            if (rowIndex < 9) {
                Permutate(rowIndex + 1);
            } else {
                solutionCount++;
                Utils.AddSolutionToDataSet(ref permutationTable, solution);
                Utils.PrintSolutionToConsole(solutionCount, solution);
                Utils.CalculateAvarageCPUCyclesPerSolution(solutionCount, ref permutationTime, ref validationCount);
                Utils.BulkPassDataSetToSql(permutationTable, total);
                permutationTime.Stop();
                permutationTime.Reset();
                breakLoop = true;
            }

            return breakLoop;
        }

        private void InitSolution()
        {
            solution.Add(Enumerations.RowNumber.One, "abcdefghi");
            solution.Add(Enumerations.RowNumber.Two, "");
            solution.Add(Enumerations.RowNumber.Three, "");
            solution.Add(Enumerations.RowNumber.Four, "");
            solution.Add(Enumerations.RowNumber.Five, "");
            solution.Add(Enumerations.RowNumber.Six, "");
            solution.Add(Enumerations.RowNumber.Seven, "");
            solution.Add(Enumerations.RowNumber.Eight, "");
            solution.Add(Enumerations.RowNumber.Nine, "");
        }
    }
}
