using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4 {
    public class PermutateOneThroughNine {
        public PermutateOneThroughNine() {
            Console.WriteLine("Working...");
            Stopwatch swtotal = new Stopwatch();
            swtotal.Start();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DataTable permutationTable = new DataTable("AIPermutation"); //TODO: Populate Table and column name from config
            permutationTable.Columns.Add("Permutation", typeof(string));

            int i = 123456788;
            string permutation = "";
            while (i < 987654321) {
                do {
                    i++;
                    i = Int32.Parse(i.ToString().Replace('0', '1'));
                    //Console.WriteLine(i);
                } while (i.ToString().Distinct().Count() != i.ToString().Length);
                permutation = i.ToString().Replace('1', 'a').Replace('2', 'b').Replace('3', 'c').Replace('4', 'd')
                    .Replace('5', 'e').Replace('6', 'f').Replace('7', 'g').Replace('8', 'h').Replace('9', 'i');
                //Console.WriteLine(permutation + " -- Committed");
                permutationTable.Rows.Add(permutation);
            }
            sw.Stop();
            Console.WriteLine("Time to generate 'a' through 'i' permutations: {0}", sw.Elapsed);
            Console.WriteLine("Number of rows in the data table: " + permutationTable.Rows.Count);

            if (false) { //TODO: Check property from config
                DAO.BulkCopyToSQLTable(permutationTable);
            } else {
                //TODO: print to text file.
            }
            swtotal.Stop();
            Console.WriteLine("Total Execution Time: {0}", swtotal.Elapsed);
            Console.ReadLine();
        }

        
    }
}
