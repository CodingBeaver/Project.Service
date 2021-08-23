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
    public class MakeController : ApiController
    {
        public IMapper Mapper { get; set; }
        public IVehicleService Service { get; set; }

  

        public MakeController(IVehicleService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        //[Route("api/make/{FilterSting?}&{SortField?}&{SortDirection?}&{Pages?}&{PagesSize?}")]
        public async Task<HttpResponseMessage> GetAll([FromUri]Filter filter,[FromUri]Sort sort, [FromUri]Paging paging)
        {
            try
            {
                var response = Mapper.Map<List<TempMake>>(await Service.MakeGetAll(filter, sort, paging));
                return Request.CreateResponse(response);
            }
            catch(Exception ex) {
                return Request.CreateResponse(ex.Message);
            }
            
        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetById([FromUri] Guid id)
        {
            var response = await Service.MakeById(id);
            if (response == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] TempMake newMake)
        {
            try
            {
                var make = Mapper.Map<IVehicleMake>(newMake);
                await Service.AddMake(make);
                return Request.CreateResponse(System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] TempMake update, Guid id)
        {
            try {
                var make = Mapper.Map<IVehicleMake>(update);
                var response=await Service.UpdateMake(make, id);
                return Request.CreateResponse(response);
            } catch (Exception ex){
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            
            
        }

        [HttpDelete]

        public async Task<HttpResponseMessage> Delete([FromUri] Guid id)
        {
            try
            {
                await Service.DeleteMake(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }






    }

}