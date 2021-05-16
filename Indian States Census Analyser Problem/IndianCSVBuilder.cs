using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indian_States_Census_Analyser_Problem
{   

    public interface IndianCSVBuilder
    {
        object LoadCSVFileData(string csvFilePath, string fileHeaders);
    }
}
