using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Search;

namespace Azure_Search_and_Recommendations_Demo.Models
{
    public class Car
    {
        //    [Key]
        //    public int Id { get; set; }

        [Key]
        public int Id { get; set; }

        [IsSearchable, IsFilterable, IsSortable]
        public string Make { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string Model { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public int Year { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public int Rating { get; set; }

    }
}