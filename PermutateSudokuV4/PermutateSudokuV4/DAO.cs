using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4
{
    class DAO
    {
        public static void BulkCopyToSQLTable(DataTable permutationTable)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
                "PermutateSudokuV4.Properties.Settings.SudokuPermutationsV4ConnectionString"].ConnectionString)) {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection)) {
                    bulkCopy.DestinationTableName = "AIPermutation";
                    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Permutation", "Permutation"));
                    try {
                        bulkCopy.WriteToServer(permutationTable);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Time to bulk copy data to table: {0}", sw.Elapsed);
        }

        public static List<string> GetAIPermutations()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
                "PermutateSudokuV4.Properties.Settings.SudokuPermutationsV4ConnectionString"].ConnectionString)) {
                DataSet ds = new DataSet();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From AIPermutation";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                foreach(DataRow row in ds.Tables[0].Rows) {
                    result.Add(row[0].ToString());
                }
            }
            return result;
        }
    }
}
