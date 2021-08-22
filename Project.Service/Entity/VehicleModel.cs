using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Service.Entity
{
    public class VehicleModel : IVehicleModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? Id { get; set; }

        [ForeignKey("VehicleMake")]
        public Guid MakeId { get; set; }
  
        public VehicleMake VehicleMake { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }
    }
}