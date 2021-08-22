using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public class Sort : ISort
    {
        public string SortField{get; set;}

        public string SortDirection { get; set; }
    }
}