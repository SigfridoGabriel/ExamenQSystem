using Newtonsoft.Json;
using Parte02.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parte02.Controllers
{
    public class OrdenesPagoController : ApiController
    {

        // GET: api/OrdenesPago/5
        [HttpGet]
        public string OrdenesPagoSucursal(string sucursal, string moneda)
        {
            var conn = ConfigurationManager.ConnectionStrings["Examen"].ToString();
            var opr = new OrdenesPagoRepository(conn);
            var retorno = opr.ObtenerOrdenesPagoSucursal(sucursal, moneda);
            var json = JsonConvert.SerializeObject(retorno);
            return json;
        }

        // POST: api/OrdenesPago
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrdenesPago/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdenesPago/5
        public void Delete(int id)
        {
        }
    }
}
