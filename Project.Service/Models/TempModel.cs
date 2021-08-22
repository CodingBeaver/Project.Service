using Project.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public class TempModel : IVehicleModel
    {
        public Guid? Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }

        public string Abrv { get; set; }

    }
}