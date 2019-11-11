using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasCapas.DTO;
namespace VentasCapas.Business
{
    public static class Clientes
    {
        public static List<ClientesDTO> ConsultarTodos()
        {
            return DAO.ClientesDAO.ReadAll("");
        }

        public static List<ClientesDTO> ConsultarPorNombre(string filtro)
        {
            filtro = filtro.Replace("'", "");
            return DAO.ClientesDAO.ReadAll("WHERE Nombre LIKE '%" + filtro + "%'");
        }

        public static ClientesDTO ConsultarPorId(int id)
        {
            var list = DAO.ClientesDAO.ReadAll("WHERE ID = " + id.ToString());
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public static void Actualizar(ClientesDTO cliente)
        {
            DAO.ClientesDAO.Update(cliente);
        }

        public static void Crear(ClientesDTO cliente)
        {
            DAO.ClientesDAO.Create(cliente);
        }

        public static void Eliminar(int id)
        {
            DAO.ClientesDAO.Delete(id);
        }
    }
}