using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.DAO
{
    public static class VendedoresDAO
    {
        public static List<VendedoresDTO> ReadAll(string where)
        {
            DataTable dt = new DataTable();

            //Leo los registros de la DB.
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM VENDEDORES " + where,
                DAOHelper.connectionString))
            {
                da.Fill(dt);
            }

            VendedoresDTO dto;
            List<VendedoresDTO> lista = new List<VendedoresDTO>();

            //Itero entre los registros para armar la Lista de DTO.
            foreach (DataRow dr in dt.Rows)
            {
                dto = new VendedoresDTO();

                if (!dr.IsNull("Id")) dto.Id = (int)dr["Id"];
                if (!dr.IsNull("Nombre")) dto.Nombre = (string)dr["Nombre"];
                if (!dr.IsNull("Apellido")) dto.Apellido = (string)dr["Apellido"];
                if (!dr.IsNull("Legajo")) dto.Legajo = (string)dr["Legajo"];
                if (!dr.IsNull("Turno")) dto.Turno = (string)dr["Turno"];

                lista.Add(dto);
            }

            return lista;
        }

        public static int Update(VendedoresDTO vendedores)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Vendedores SET Nombre='[nombre]', Apellido='[apellido]', Legajo='[legajo]', Turno='[turno]' WHERE Id=" + vendedores.Id;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[nombre]", vendedores.Nombre);
                    cmd.CommandText = cmd.CommandText.Replace("[apellido]", vendedores.Apellido);
                    cmd.CommandText = cmd.CommandText.Replace("[legajo]", vendedores.Legajo);
                    cmd.CommandText = cmd.CommandText.Replace("[turno]", vendedores.Turno);

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static VendedoresDTO Create(VendedoresDTO vendedores)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO Vendedores (Id, Nombre, Apellido, Legajo, Turno) 
                                        VALUES ([id],'[nombre]','[apellido]','[legajo]','[turno]')";

                    int proximoId = DAOHelper.GetNextId("Vendedores");
                    vendedores.Id = proximoId;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[id]", proximoId.ToString());
                    cmd.CommandText = cmd.CommandText.Replace("[nombre]", vendedores.Nombre);
                    cmd.CommandText = cmd.CommandText.Replace("[apellido]", vendedores.Apellido);
                    cmd.CommandText = cmd.CommandText.Replace("[legajo]", vendedores.Legajo);
                    cmd.CommandText = cmd.CommandText.Replace("[turno]", vendedores.Turno);

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return vendedores;
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
                    cmd.CommandText = "DELETE Vendedores WHERE Id=" + id;

                    //Ejecuto el delete.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
