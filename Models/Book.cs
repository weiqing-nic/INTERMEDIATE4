using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Book
    {
        [Required]
        public string Id { get; set; }
        public string UpdatedTime { get; set; }
        public string ChartName { get; set; }

        public string USDRATE { get; set; }

        public string USDRATEFLOAT { get; set; }
    }
}
