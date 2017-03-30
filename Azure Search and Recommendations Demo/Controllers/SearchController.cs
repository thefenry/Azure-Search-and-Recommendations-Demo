using System.Collections.Generic;
using System.Web.Http;

namespace Azure_Search_and_Recommendations_Demo.Controllers
{
    public class SearchController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> GetCars()
        {
            return new string[] { "car1", "car2" };
        }
    }
}