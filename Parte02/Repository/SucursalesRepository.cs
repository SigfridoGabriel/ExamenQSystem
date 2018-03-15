using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parte02.Repository
{
    public class SucursalesRepository
    {
        public string DefaultConnection { get; set; }

        public SucursalesRepository(string connection)
        {
            this.DefaultConnection = connection;
        }

        public IList<Models.Sucursales> ObtenerSucursalesPorbanco(string banco)
        {
            try
            {
                var sucursales = new List<Models.Sucursales>();
                using (var connection = new SqlConnection(DefaultConnection))
                {
                    connection.Open();
                    var command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "ObtenerSucursalesPorbanco",
                        CommandTimeout = 0
                    };

                    command.Parameters.Add(new SqlParameter("@banco", banco));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var _sucursales = new Models.Sucursales
                            {
                                IdSucursal = Convert.ToInt32(reader["IdSucursal"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString())
                            };
                            sucursales.Add(_sucursales);
                        }
                    }
                }

                return sucursales;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}