using Parte02.Models;
using Parte02.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;

namespace Parte02.Controllers
{
    public class SucursalesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage SucursalesPorBanco(string banco)
        {
            var conn = ConfigurationManager.ConnectionStrings["Examen"].ToString();
            var sr = new SucursalesRepository(conn);
            var retorno = sr.ObtenerSucursalesPorbanco(banco);
            var serializer = new XmlSerializer(typeof(List<Sucursales>));
            var stringwriter = new System.IO.StringWriter();
            serializer.Serialize(stringwriter, retorno);
            return new HttpResponseMessage()
            {
                Content = new StringContent(stringwriter.ToString(), Encoding.UTF8, "application/xml")
            };
        }
    }
}
