using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public class Paging: IPaging
    {
        int pageSize = 20;
        public int? Pages { get; set; }

        public int? PageSize
        {
            get => pageSize;
            set
            {   if(value!=null)pageSize = (int)value;
            }
        }
    }
}