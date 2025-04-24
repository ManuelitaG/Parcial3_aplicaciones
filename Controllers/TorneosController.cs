using Parcial3_aplicaciones.Clases;
using Parcial3_aplicaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial3_aplicaciones.Controllers
{
    [RoutePrefix("api/torneos")]
    [Authorize]
    public class TorneosController : ApiController
    {
        [HttpPost]
        [Route("guardar")]
        public string Insertar([FromBody] Torneo torneo)
        {
            clsTorneos torneos = new clsTorneos();
            torneos.torneo = torneo;
            return torneos.Guardar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            clsTorneos torneos = new clsTorneos();
            torneos.torneo = torneo;
            return torneos.Actualizar(torneo.idTorneos, torneo);
        }

        [HttpDelete]
        [Route("eliminar")]
        public string Eliminar([FromBody] Torneo torneo)
        {
            clsTorneos torneos = new clsTorneos();
            torneos.torneo = torneo;
            return torneos.Eliminar(torneo.idTorneos);
        }

        [HttpGet]
        [Route("consultar")]
        public List<Torneo> ConsultarTorneos(string tipo, string nombre, DateTime fecha)
        {
            clsTorneos torneos = new clsTorneos();
            return torneos.ConsultarTorneos(tipo, nombre, fecha);
        }
    }
}
