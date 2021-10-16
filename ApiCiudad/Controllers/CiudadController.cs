using System.Collections.Generic;
using ApiCiudad.Interfaces;
using ApiCiudad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCiudad.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICrudCiudad crudCiudad;

        public CiudadController(ICrudCiudad crudCiudad)
        {
            this.crudCiudad = crudCiudad;
        }

        [HttpPost]
        [Route("lista")]
        public List<Ciudad> ListaCiudades([FromBody] Ciudad ciudad)
        {
            List<Ciudad> c = crudCiudad.SpMetodos(ciudad);
            return c;
        }
    }
}
