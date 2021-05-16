using Indian_States_Census_Analyser_Problem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Indian_States_Census_Analyser_Problem.CensorAnalyser;

namespace Indian_States_Census_Analyser_Problem_Test
{
    public class Tests //test class
    {
        //UC1
        static string CSVFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\CensorAnalyser.cs";
        static string InvalidDeliminatorFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IncorrectDeliminatorCensusFile.csv";
        static string InvalidHeaderFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\DelimiterIndiaStateCode.csv";
        
        //UC2
        static string CSVStateCodeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCode.csv";
        static string InvalidDeliminatorStateCodeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\InvalidDeliminatorIndiaStateCode.csv";

        static string StateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm"; //file header
        static string StateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";//state code file header

        CensorAnalyser censusAnalyser;
        CSVFileData csvFileData;
        CSVFactory csvFactory;
        List<string> totalNumberOfRecords;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfRecords = new List<string>();
        }

        /* TC1.1:- Given the States Census CSV file, Check to ensure the Number of Record matches.
                   This is a Happy Test Case where the records are checked.
         */
        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            try {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (List<string>)csvFileData(CSVFilePath, StateCensusFileHeaders);
            Assert.AreEqual(29, totalNumberOfRecords.Count);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /* TC1.2:- Given the State Census CSV File if incorrect Returns a custom Exception.
                   This is a Sad Test Case to verify if the exception is raised. 
         */
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            try 
            {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCensusFileHeaders));
            }
            catch(CensusAnalyserException ex)
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
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCensusFileHeaders));
            }
            catch(CensusAnalyserException ex)
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
            try { 
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorFilePath, StateCensusFileHeaders));
            }
            catch(CensusAnalyserException ex)
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
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCensusFileHeaders));
            }
            catch(CensusAnalyserException ex)
            {
                          Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }
        }

        /* 2.1:- Given the States Census CSV file, Check to ensure the Number of Record matches.
                 This is a Happy Test Case where the records are checked.
        */

        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
          
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (List<string>)csvFileData(CSVStateCodeFilePath, StateCodeFileHeaders);
            Assert.AreEqual(37, totalNumberOfRecords.Count);
        }

        /* TC2.2:- Given the State Census CSV File if incorrect Returns a custom Exception.
                  This is a Sad Test Case to verify if the exception is raised. 
        */
        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            try
            {

            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCodeFileHeaders));

            }
            catch(CensusAnalyserException ex)
            {           
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }
        /* TC2.3:- Given the State Census CSV File when correct but type incorrect Returns a custom Exception.
               This is a Sad Test Case to verify if the type is incorrect then exception is raised.
       */
        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            try
            {

                CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCodeFileHeaders));
            }
            catch (CensusAnalyserException ex)
            { 
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, ex.type);
            }

        }
        /* TC2.4:- Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception.
                  This is a Sad Test Case to verify if the file delimiter is incorrect then exception is raised.
        */
        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            try
            {           
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorStateCodeFilePath, StateCodeFileHeaders));
            }
            catch(CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, ex.type);
            }               
        }
        /* TC2.5:- Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception.
                   This is a Sad Test Case to verify if the header is incorrect then exception is raised.
         */
        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            try
            {           
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCodeFileHeaders));
            }
            catch(CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }
                
        }
    }
}