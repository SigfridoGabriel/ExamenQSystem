using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parte02.Repository
{
    public class OrdenesPagoRepository
    {
        public string DefaultConnection { get; set; }

        public OrdenesPagoRepository(string connection)
        {
            this.DefaultConnection = connection;
        }

        public IList<Models.OrdenesPago> ObtenerOrdenesPagoSucursal(string sucursal, string moneda)
        {
            try
            {
                var ordenesPago = new List<Models.OrdenesPago>();
                using (var connection = new SqlConnection(DefaultConnection))
                {
                    connection.Open();
                    var command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "ObtenerOrdenesPagoSucursal",
                        CommandTimeout = 0
                    };

                    command.Parameters.Add(new SqlParameter("@sucursal", sucursal));
                    command.Parameters.Add(new SqlParameter("@moneda", moneda));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var _ordenesPago = new Models.OrdenesPago
                            {
                                IdOrdenPago = Convert.ToInt32(reader["IdOrdenPago"].ToString()),
                                Monto = Convert.ToDecimal(reader["Monto"].ToString()),
                                Moneda = reader["Moneda"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                FechaPago = Convert.ToDateTime(reader["FechaPago"].ToString())
                            };
                            ordenesPago.Add(_ordenesPago);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return ordenesPago;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}