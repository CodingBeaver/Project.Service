using AutoMapper;
using Project.Service.Entity;
using Project.Service.Models;
using Project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Project.Service.Controllers
{
    public class ModelController : ApiController
    {

        public IMapper Mapper { get; set; }
        public IVehicleService Service { get; set; }

        public ModelController(IVehicleService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAll([FromUri] Filter filter, [FromUri] Sort sort, [FromUri] Paging paging)
        {
            try
            {
                var response = Mapper.Map<List<TempModel>>(await Service.ModelGetAll(filter, sort, paging));
                return Request.CreateResponse(response);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetById([FromUri] Guid id)
        {
            var response = await Service.ModelById(id);
            if (response == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] TempModel newModel)
        {
            try
            {
                var model = Mapper.Map<IVehicleModel>(newModel);
                await Service.AddModel(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return  Request.CreateResponse(System.Net.HttpStatusCode.NotFound, ex.Message);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] TempModel update, Guid id)
        {
            try
            {
                var model = Mapper.Map<IVehicleModel>(update);
                var response = await Service.UpdateModel(model, id);
                return Request.CreateResponse(response);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [HttpDelete]

        public async Task<HttpResponseMessage> Delete([FromUri] Guid id)
        {
            try
            {
                await Service.DeleteModel(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, ex.Message);
            }
        }

    }

}