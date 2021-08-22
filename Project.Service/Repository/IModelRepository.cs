using Project.Service.Entity;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public interface IModelRepository
    {



        Task<List<IVehicleModel>> GetAll(Filter filter, Sort sort, Paging paging);

        Task<IVehicleModel> GetById(Guid id);

        Task Add(IVehicleModel model);

        Task<IVehicleModel> Update(IVehicleModel model, Guid id);

        Task Delete(Guid id);
    }
}