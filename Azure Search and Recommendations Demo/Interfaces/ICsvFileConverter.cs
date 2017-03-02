using System.Collections.Generic;
using Azure_Search_and_Recommendations_Demo.Models;

namespace Azure_Search_and_Recommendations_Demo.Interfaces
{
    interface ICsvFileConverter
    {
        string ConvertModelToCsv(List<Car> list);
    }
}
