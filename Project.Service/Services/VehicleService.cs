using Project.Service.Entity;
using Project.Service.Models;
using Project.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {   
        public IMakeRepository MakeRepo { get; set; }

        public IModelRepository ModelRepo { get; set; }

        public VehicleService(IMakeRepository makeRepo, IModelRepository modelRepo)
        {
            this.MakeRepo = makeRepo;
            this.ModelRepo = modelRepo;
        }

        public async Task<List<IVehicleMake>> MakeGetAll(Filter filter, Sort sort, Paging paging)
        {
            var response = await MakeRepo.GetAll(filter, sort, paging);
           
            return response;
        }

        public async Task<IVehicleMake> MakeById(Guid id)
        {
           return  await MakeRepo.GetById(id);
        }

        public async Task AddMake(IVehicleMake make)
        {
            await MakeRepo.Add(make);
        }

        public  async Task<IVehicleMake> UpdateMake(IVehicleMake make, Guid id)
        {
            var response= await MakeRepo.Update(make,id);
            return response;
        }

        public async Task DeleteMake(Guid id)
        {
            await MakeRepo.Delete(id);
        }

        public async Task<List<IVehicleModel>> ModelGetAll(Filter filter, Sort sort, Paging paging)
        {
            var response = await ModelRepo.GetAll(filter, sort, paging);
            return response;
        }

        public async Task<IVehicleModel> ModelById(Guid id)
        {
            var response = await ModelRepo.GetById(id);
            return response;
        }

        public async Task AddModel(IVehicleModel model)
        {
            await ModelRepo.Add(model);
        }

        public async Task<IVehicleModel> UpdateModel(IVehicleModel model, Guid id)
        {
            var response = await ModelRepo.Update(model, id);
            return response;
         }

        public  async Task DeleteModel(Guid id)
        {
            await ModelRepo.Delete(id);
        }
    }

    
}