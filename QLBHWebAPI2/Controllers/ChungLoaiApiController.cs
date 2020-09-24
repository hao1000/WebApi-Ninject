using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLBHRepository.DTO;
using QLBHRepository.BLL;
using System.Threading.Tasks;

namespace QLBHWebAPI2.Controllers
{
   

    public class ChungLoaiApiController : ApiController
    {
        private readonly IChungLoaiRepository _repositoryCL;

        public ChungLoaiApiController(IRepository repository)
        {
            _repositoryCL = repository.ChungLoai;
        }
        [Route("doc-tat-ca")]
        [HttpGet]
        //[ResponseType(typeof(object))]
        public async Task<IHttpActionResult> DocTatCa()
        {
            try
            {
                var item = _repositoryCL.GetAll();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Loi khong truy cap duoc du lieu. Ly do : {ex.Message}");
            }
        }
    }
}
