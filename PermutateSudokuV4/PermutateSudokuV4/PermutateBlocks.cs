using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;

namespace PermutateSudokuV4
{
    class PermutateBlocks
    {
        public PermutateBlocks()
        {
            List<string> rows = DAO.GetAIPermutations();

            Dictionary<string, string> blockPermutation = new Dictionary<string, string>();
            blockPermutation.Add("Row 1", "");
            blockPermutation.Add("Row 2", "");

            DataTable permutationTable = new DataTable("AIPermutation");
            permutationTable.Columns.Add("Permutation", typeof(string));

            //Stopwatch sw = new Stopwatch();
            Stopwatch total = new Stopwatch();
            Console.WriteLine("Starting....");
            total.Start();
            //int count = 0;
            //int seedcount = 0;
            foreach (string row1 in rows) {
                //seedcount++;
                //sw.Start();
                blockPermutation["Row 1"] = row1;
                foreach (string row2 in rows) {
                    blockPermutation["Row 2"] = row2;
                    if (validateBoxes(blockPermutation)) {
                        //count++;
                        permutationTable.Rows.Add(blockPermutation["Row 1"] + blockPermutation["Row 2"]);
                        if(permutationTable.Rows.Count % 1000000 == 0) {
                            Console.WriteLine(permutationTable.Rows.Count + " :: " + total.Elapsed);
                        }
                    }
                }
                blockPermutation["Row 2"] = "";
                //sw.Stop();
                //Debug.WriteLine("For seed row #" + seedcount + ", " + count + " solutions generated in " + sw.Elapsed + " time. Total elapsed time: " + total.Elapsed);
                //sw.Reset();
                //count = 0;
            }
            //total.Stop();
            //Console.WriteLine("Total execution time: " + total.Elapsed);
            Console.ReadLine();
        }

        private bool validateBoxes(Dictionary<string, string> blockPermutation)
        {
            bool result = true;
            List<string> boxes = new List<string>();
            
            boxes.Add("");
            boxes.Add("");
            boxes.Add("");

            boxes[0] += blockPermutation["Row 1"].Substring(0, 3) + blockPermutation["Row 2"].Substring(0, 3);
            boxes[1] += blockPermutation["Row 1"].Substring(3, 3) + blockPermutation["Row 2"].Substring(3, 3);
            boxes[2] += blockPermutation["Row 1"].Substring(6, 3) + blockPermutation["Row 2"].Substring(6, 3);

            foreach (string box in boxes) {
                if (box.Distinct().Count() != box.Length) {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
