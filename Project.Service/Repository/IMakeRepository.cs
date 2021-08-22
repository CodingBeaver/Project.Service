using Project.Service.Entity;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public interface IMakeRepository
    {

        Task<List<IVehicleMake>> GetAll(Filter filter, Sort sort, Paging paging);

        Task<IVehicleMake> GetById(Guid id);

        Task Add(IVehicleMake make);

        Task<IVehicleMake> Update(IVehicleMake make, Guid id);

        Task Delete(Guid id);
    }
}