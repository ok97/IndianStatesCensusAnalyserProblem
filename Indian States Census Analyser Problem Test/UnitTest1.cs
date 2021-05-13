using Indian_States_Census_Analyser_Problem;
using NUnit.Framework;

namespace Indian_States_Census_Analyser_Problem_Test
{
    public class Tests //test class
    {
        static string CSVFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        
        CensorAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensorAnalyser();
        }

        /* TC1.1:- Given the States Census CSV file, Check to ensure the Number of Record matches.
                   This is a Happy Test Case where the records are checked.
         */
        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords() //method count Check to ensure the Number of Record matches 
        {
           int ExpectedCount = 29; //initilise count value
            string[] actual = censusAnalyser.LoadIndianCensusCSVData(CSVFilePath); // acces file csv
            Assert.AreEqual(ExpectedCount, actual.Length); //match
        }

        /* TC1.2:- Given the State Census CSV File if incorrect Returns a custom Exception.
                   This is a Sad Test Case to verify if the exception is raised. 
         */
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }

    }
}