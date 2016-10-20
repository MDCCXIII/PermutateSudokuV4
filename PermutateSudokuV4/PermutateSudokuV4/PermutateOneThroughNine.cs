using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateSudokuV4 {
    public class PermutateOneThroughNine {
        public PermutateOneThroughNine() {
            List<string> result = new List<string>();
            int i = 123456788;
            while(i < 987654321) {
                do {
                    i++;
                    i = Int32.Parse(i.ToString().Replace('0', '1'));
                } while (i.ToString().Distinct().Count() != i.ToString().Length); 
                result.Add(i.ToString().Replace('1', 'a').Replace('2', 'b').Replace('3', 'c').Replace('4', 'd').Replace('5', 'e').Replace('6', 'f').Replace('7', 'g').Replace('8', 'h').Replace('9', 'i'));
            }
            Console.ReadLine();
        }
    }
}
