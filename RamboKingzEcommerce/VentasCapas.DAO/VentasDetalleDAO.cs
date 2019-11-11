using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.DAO
{
    public static class VentasDetalleDAO
    {
        public static List<VentasDetalleDTO> ReadAll(string where)
        {
            DataTable dt = new DataTable();

            //Leo los registros de la DB.
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM VentasDetalle " + where,
                DAOHelper.connectionString))
            {
                da.Fill(dt);
            }

            VentasDetalleDTO dto;
            List<VentasDetalleDTO> lista = new List<VentasDetalleDTO>();

            //Itero entre los registros para armar la Lista de DTO.
            foreach (DataRow dr in dt.Rows)
            {
                dto = new VentasDetalleDTO();

                if (!dr.IsNull("Id")) dto.Id = (int)dr["Id"];
                if (!dr.IsNull("IdVentaCabecera")) dto.IdVentaCabecera = (int)dr["IdVentaCabecera"];
                if (!dr.IsNull("IdArticulo")) dto.IdArticulo = (int)dr["IdArticulo"];
                if (!dr.IsNull("PrecioUnitario")) dto.PrecioUnitario = (decimal)dr["PrecioUnitario"];
                if (!dr.IsNull("Cantidad")) dto.Cantidad = (int)dr["Cantidad"];

                lista.Add(dto);
            }

            return lista;
        }

        public static int Update(VentasDetalleDTO venta)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE VentasDetalle SET IdArticulo='[idarticulo]', IdVentaCabecera='[idventacabecera]', PrecioUnitario=[preciounitario], Cantidad ='[cantidad]' WHERE Id=" + venta.Id;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[idarticulo]", venta.IdArticulo.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idventacabecera]", venta.IdVentaCabecera.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[preciounitario]", venta.PrecioUnitario.ToString(System.Globalization.CultureInfo.InvariantCulture));       //El "InvariantCulture" es para que el ToString() ponga los decimales con '.' en lugar de ','.
                    cmd.CommandText = cmd.CommandText.Replace("[precioCompra]", venta.Cantidad.ToString());

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static VentasDetalleDTO Create(VentasDetalleDTO venta)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO VentasDetalle (Id, IdArticulo, IdVentaCabecera, PrecioUnitario, Cantidad) 
                                        VALUES ([id],'[idarticulo]','[idventacabecera]',[preciounitario],[cantidad])";

                    int proximoId = DAOHelper.GetNextId("VentasDetalle");
                    venta.Id = proximoId;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[id]", proximoId.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idarticulo]", venta.IdArticulo.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[idventacabecera]", venta.IdVentaCabecera.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[preciounitario]", venta.PrecioUnitario.ToString(System.Globalization.CultureInfo.InvariantCulture));       //El "InvariantCulture" es para que el ToString() ponga los decimales con '.' en lugar de ','.
                    cmd.CommandText = cmd.CommandText.Replace("[cantidad]", venta.Cantidad.ToString());

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
                    cmd.CommandText = "DELETE VentasDetalle WHERE Id=" + id;

                    //Ejecuto el delete.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
