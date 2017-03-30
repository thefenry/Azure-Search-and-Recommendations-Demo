using System.Collections.Generic;
using Azure_Search_and_Recommendations_Demo.Models;
using System.IO;

namespace Azure_Search_and_Recommendations_Demo.Interfaces
{
    interface ICsvFileConverter
    {
        FileInfo ConvertModelToCsv(List<Car> list);
    }
}
