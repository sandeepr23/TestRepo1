using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    class Program
    {

        private static string longestWord = string.Empty;
        private static string secondlongestWord = string.Empty;
        private static List<String> InputList = new List<string>();
        private static List<String> ConcatenatedStrings = new List<string>();

        static void Main(string[] args)
        {
             String inputString;
            long stringCount= 0;
            //var trie =new Trie()

            using (StreamReader fileReader = new StreamReader("c://source/NET Test 00.txt"))
            {
                Console.WriteLine(string.Format("Startime {0}", DateTime.Now));
                while (!String.IsNullOrEmpty(inputString = fileReader.ReadLine()))
                {
                    ProcessString(inputString);
                    stringCount++;
                }
               
                Console.WriteLine(string.Format("Longest Word {0}",longestWord));
                Console.WriteLine(string.Format("Second Longest Word {0}",secondlongestWord));
                Console.WriteLine("Finished process file");
                Console.WriteLine(string.Format("Total number of string count{0}",stringCount));
                Console.WriteLine(string.Format("Endtime {0}", DateTime.Now));
                Console.ReadLine();
            }
        }

        private static void ProcessString(string inputString)
        {
            if (IsWordConcattenatedString(inputString))
            {
                if (inputString.Length > longestWord.Length)
                {
                    secondlongestWord = longestWord;
                    longestWord = inputString;
                }
                
                ConcatenatedStrings.Add(inputString);
            }
            InputList.Add(inputString);
            //Console.WriteLine(inputString);
        }

        private static bool IsWordConcattenatedString(string inputString)
        {
            string startWord = string.Empty;

            foreach (String inputUniqueString in InputList)
            {
                if (inputUniqueString.Equals(inputString))
                {
                    return true;
                }                    

                if (inputString.StartsWith(inputUniqueString))
                {
                    if (inputUniqueString.Length > startWord.Length)
                    {
                        startWord = inputUniqueString;
                    }
                }
            }

            return !string.IsNullOrEmpty(startWord) ? IsWordConcattenatedString(inputString.Substring(startWord.Length)) : false;
        }
    }
}
