using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.DAO
{
    public static class ClienteDAO
    {
        public static List<ClienteDTO> ReadAll(string where)
        {
            DataTable dt = new DataTable();

            //Leo los registros de la DB.
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM CLIENTES " + where,
                DAOHelper.connectionString))
            {
                da.Fill(dt);
            }

            ClienteDTO dto;
            List<ClienteDTO> lista = new List<ClienteDTO>();

            //Itero entre los registros para armar la Lista de DTO.
            foreach (DataRow dr in dt.Rows)
            {
                dto = new ClienteDTO();

                if (!dr.IsNull("Id")) dto.Id = (int)dr["Id"];
                if (!dr.IsNull("Nombre")) dto.Nombre = (string)dr["Nombre"];
                if (!dr.IsNull("Direccion")) dto.Direccion = (string)dr["Direccion"];
                if (!dr.IsNull("Telefono")) dto.Telefono = (string)dr["Telefono"];
                if (!dr.IsNull("Email")) dto.Email = (string)dr["Email"];

                lista.Add(dto);
            }

            return lista;
        }
    }
}
