using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indian_States_Census_Analyser_Problem
{
    public class CensorAnalyser : IndianCSVBuilder
    { /* UC1:- Ability for the analyser to load the Indian States Census Information from a csv file.
               - Create a StateCensusAnalyser Class to load the State Census CSV Data.
               - Create CSVStateCensus Class to load the CSV Data.
               - Use Iterator to load the data.
               - Check with StateCensusAnalyser to ensure UC 1 number of record matche.
      */
        public delegate object CSVFileData(string csvFilePath, string fileHeaders);
        List<string> censusData = new List<string>();

        // string[] censusData;
        public object LoadCSVFileData(string csvFilePath, string fileHeaders)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath).ToList();
            if (censusData[0] != fileHeaders)
            {
                throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
            }
            foreach (string data in censusData)
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }
            return censusData.Skip(1).ToList();
        }
        public static void Main(string [] args)
        {
            Console.WriteLine("Indian States Census Analyser Problem");
        }

        
    }    
}

