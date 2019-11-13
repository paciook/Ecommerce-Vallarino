using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.DAO
{
    public static class ClientesDAO
    {
        public static List<ClientesDTO> ReadAll(string where)
        {
            DataTable dt = new DataTable();

            //Leo los registros de la DB.
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Clientes " + where,
                DAOHelper.connectionString))
            {
                da.Fill(dt);
            }

            ClientesDTO dto;
            List<ClientesDTO> lista = new List<ClientesDTO>();

            //Itero entre los registros para armar la Lista de DTO.
            foreach (DataRow dr in dt.Rows)
            {
                dto = new ClientesDTO();

                if (!dr.IsNull("Id")) dto.Id = (int)dr["Id"];
                if (!dr.IsNull("Nombre")) dto.Nombre = (string)dr["nombre"];
                if (!dr.IsNull("Direccion")) dto.Direccion = (string)dr["direccion"];
                if (!dr.IsNull("Telefono")) dto.Telefono = (string)dr["telefono"];
                if (!dr.IsNull("Email")) dto.Email = (string)dr["email"];

                lista.Add(dto);
            }

            return lista;
        }

        public static int Update(ClientesDTO clientes)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Clientes SET Nombre='[Nombre]', Direccion='[Direccion]', Telefono='[Telefono]', Email='[Email]' WHERE Id=" + clientes.Id;

                    //Reemplazo los valores de los campos en el query.
                    cmd.CommandText = cmd.CommandText.Replace("[Nombre]", clientes.Nombre);
                    cmd.CommandText = cmd.CommandText.Replace("[Direccion]", clientes.Direccion);
                    cmd.CommandText = cmd.CommandText.Replace("[Telefono]", clientes.Telefono);
                    cmd.CommandText = cmd.CommandText.Replace("[Email]", clientes.Email);

                    //Ejecuto el update.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static ClientesDTO Create(ClientesDTO clientes)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(DAOHelper.connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    var list = ReadAll("Where Usuario='" + clientes.Usuario + "'");

                    if (list.Count == 0)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"INSERT INTO Clientes (Id, Nombre, Direccion, Telefono, Email, Usuario, Contraseña) 
                                            VALUES ([id],'[nombre]','[direccion]','[telefono]','[email]', '[usuario]', '[contraseña]')";

                        int proximoId = DAOHelper.GetNextId("Clientes");
                        clientes.Id = proximoId;

                        //Reemplazo los valores de los campos en el query.
                        cmd.CommandText = cmd.CommandText.Replace("[id]", proximoId.ToString());
                        cmd.CommandText = cmd.CommandText.Replace("[nombre]", clientes.Nombre).ToString();
                        cmd.CommandText = cmd.CommandText.Replace("[direccion]", clientes.Direccion).ToString();
                        cmd.CommandText = cmd.CommandText.Replace("[telefono]", clientes.Telefono).ToString();
                        cmd.CommandText = cmd.CommandText.Replace("[email]", clientes.Email).ToString();
                        cmd.CommandText = cmd.CommandText.Replace("[usuario]", clientes.Usuario).ToString();
                        cmd.CommandText = cmd.CommandText.Replace("[contraseña]", clientes.Contraseña).ToString();

                        //Ejecuto el update.
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return clientes;
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
                    cmd.CommandText = "DELETE Clientes WHERE Id=" + id;

                    //Ejecuto el delete.
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
