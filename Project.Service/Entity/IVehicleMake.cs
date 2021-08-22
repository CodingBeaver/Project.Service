using System;

namespace Project.Service.Entity
{
    public interface IVehicleMake
    {


        Guid? Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}