using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indian_States_Census_Analyser_Problem
{
    public class CensorAnalyser
    { /* UC1:- Ability for the analyser to load the Indian States Census Information from a csv file.
               - Create a StateCensusAnalyser Class to load the State Census CSV Data.
               - Create CSVStateCensus Class to load the CSV Data.
               - Use Iterator to load the data.
               - Check with StateCensusAnalyser to ensure UC 1 number of record matche.
      */
        string[] censusData;
        public string[] LoadIndianCensusCSVData(string csvFilePath)
        {

            if (!File.Exists(csvFilePath)) //check file exist or not
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND); //throw user exception
            }
            if (Path.GetExtension(csvFilePath) != ".csv") //check file extension
            {
                throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);//throw user exception
            }
            censusData = File.ReadAllLines(csvFilePath); //read all lines
            if (censusData[0] != "State,Population,AreaInSqKm,DensityPerSqKm") //check headers
            {
                throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);//throw user exception
            }
            foreach (string data in censusData)
            {
                if (!data.Contains(",")) //check 
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);//throw user exception
                }
            }
            return censusData.Skip(1).ToArray();
        }
        public static void Main(string [] args)
        {
            Console.WriteLine("Indian States Census Analyser Problem");
        }
    }    
}

