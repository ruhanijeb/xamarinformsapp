using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReactiveUIDemo.Models
{
    public class MovieDto
    {
        public int Page { get; set; }
        [SuppressMessage("Design", "CA2227: Change to be read-only by removing the property setter.", Justification = "Used in DTO object.")]
        public IList<MovieResult> Results { get; set; }

        public MovieDates Dates { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }
}
