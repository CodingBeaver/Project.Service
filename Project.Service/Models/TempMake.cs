using Project.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public class TempMake :IVehicleMake
    {

        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}