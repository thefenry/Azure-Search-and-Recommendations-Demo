using Azure_Search_and_Recommendations_Demo.Models;
using System.Data.Entity;

namespace Azure_Search_and_Recommendations_Demo.DAL
{
    public class SearchContext : DbContext
    {
        public SearchContext() : base("SearchContext")
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}