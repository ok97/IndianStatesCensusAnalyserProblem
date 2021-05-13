using Indian_States_Census_Analyser_Problem;
using NUnit.Framework;

namespace Indian_States_Census_Analyser_Problem_Test
{
    public class Tests //test class
    {
        static string CSVFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\CensorAnalyser.cs";
        static string InvalidDeliminatorFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IncorrectDeliminatorCensusFile.csv";
        static string InvalidHeaderFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\DelimiterIndiaStateCode.csv";
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

        /* TC1.3:- Given the State Census CSV File when correct but type incorrect Returns a custom Exception.
                 This is a Sad Test Case to verify if the type is incorrect then exception is raised.
         */
        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidCSVTypeFilePath);//invalid file type exception
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, ex.type);
            }
        }

       /* TC1.4:- Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception.
                  This is a Sad Test Case to verify if the file delimiter is incorrect then exception is raised.
        */
        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidDeliminatorFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, ex.type);
            }
        }

       /* TC1.5:- Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception.
                  This is a Sad Test Case to verify if the header is incorrect then exception is raised.
        */
        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidHeaderFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }
        }


    }
}