using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.DAO
{
    public static class VentasCabeceraDAO
    {
        public static List<VentasCabeceraDTO> ReadAll(string where)
        {
            DataTable dt = new DataTable();

            //Leo los registros de la DB.
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM VENTASCABECERA " + where,
                DAOHelper.connectionString))
            {
                da.Fill(dt);
            }

            VentasCabeceraDTO dto;
            List<VentasCabeceraDTO> lista = new List<VentasCabeceraDTO>();

            //Itero entre los registros para armar la Lista de DTO.
            foreach (DataRow dr in dt.Rows)
            {
                dto = new VentasCabeceraDTO();

                if (!dr.IsNull("Id")) dto.Id = (int)dr["Id"];
                if (!dr.IsNull("Fecha")) dto.Fecha = DateTime.Parse("Fecha");
                if (!dr.IsNull("IdCliente")) dto.IdCliente = (int)dr["IdCliente"];
                if (!dr.IsNull("IdVendedor")) dto.IdVendedor = (int)dr["IdVendedor"];
                if (!dr.IsNull("Observaciones")) dto.Observaciones = (string)dr["Observaciones"];

                lista.Add(dto);
            }

            return lista;
        }

        public static int Update(VentasCabeceraDTO venta)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE VentasCabecera SET IdCliente=[idcliente], IdVendedor=[idvendedor], Fecha=[fecha], Observaciones=[observaciones] WHERE Id=" + venta.Id;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[idcliente]", venta.IdCliente.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idvendedor]", venta.IdVendedor.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[fecha]", venta.Fecha.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[observaciones]", venta.Observaciones);

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static VentasCabeceraDTO Create(VentasCabeceraDTO venta)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO VentasCabecera (Id, IdCliente, IdVendedor, Fecha, Observaciones) 
                                        VALUES ([id],'[idcliente]','[idvendedor]',[fecha],[observaciones])";

                    int proximoId = DAOHelper.GetNextId("VentasCabecera");
                    venta.Id = proximoId;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[id]", venta.Id.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idcliente]", venta.IdCliente.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idvendedor]", venta.IdVendedor.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[fecha]", venta.Fecha.ToString("yyyy-mm-dd"));
                    cmd.CommandText = cmd.CommandText.Replace("[observaciones]", venta.Observaciones);

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return venta;
        }

        public static int Delete(int id)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE VentasCabecera WHERE Id=" + id;

                    //Ejecuto el delete.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
