using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indian_States_Census_Analyser_Problem
{
    public class CensusAnalyserException : Exception //user definr exception class
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_TYPE, INVALID_DELIMITER, INVALID_HEADERS //exception type
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}
