using Azure_Search_and_Recommendations_Demo.Models;
using AzureSearchService;
using Microsoft.Azure.Search.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Azure_Search_and_Recommendations_Demo.Controllers
{
    public class SearchController : ApiController
    {
        private AzureSearchManager azureSearchManager = new AzureSearchManager("cars");

        // GET api/<controller>
        [HttpGet]
        public IList<SearchResult<Car>> GetCars()
        {
            return azureSearchManager.GetAllResults<Car>().Results;
        }

        [HttpPost]
        public IList<SearchResult<Car>> CarsSearch([FromBody]string searchTerm)
        {
            return azureSearchManager.SearchContent<Car>(searchTerm).Results;            
        }
    }
}