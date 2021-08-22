using Project.Service.Entity;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
     public interface IVehicleService
    {

        Task<List<IVehicleMake>> MakeGetAll(Filter filter, Sort sort, Paging paging);
        Task<IVehicleMake> MakeById(Guid id);

        Task AddMake(IVehicleMake make);

        Task<IVehicleMake> UpdateMake(IVehicleMake make, Guid id);

        Task DeleteMake(Guid id);

        Task<List<IVehicleModel>> ModelGetAll(Filter filter, Sort sort, Paging paging);
        Task<IVehicleModel> ModelById(Guid id);

        Task AddModel(IVehicleModel make);

        Task<IVehicleModel> UpdateModel(IVehicleModel model, Guid id);

        Task DeleteModel(Guid id);
    }
}
