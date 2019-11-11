using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasCapas.DTO;
namespace VentasCapas.Business
{
    public static class Vendedores
    {
        public static List<VendedoresDTO> ConsultarTodos()
        {
            return DAO.VendedoresDAO.ReadAll("");
        }

        public static List<VendedoresDTO> ConsultarPorNombre(string filtro)
        {
            filtro = filtro.Replace("'", "");
            return DAO.VendedoresDAO.ReadAll("WHERE Nombre LIKE '%" + filtro + "%'");
        }

        public static VendedoresDTO ConsultarPorId(int id)
        {
            var list = DAO.VendedoresDAO.ReadAll("WHERE ID = " + id.ToString());
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public static void Actualizar(VendedoresDTO vendedor)
        {
            DAO.VendedoresDAO.Update(vendedor);
        }

        public static void Crear(VendedoresDTO vendedor)
        {
            DAO.VendedoresDAO.Create(vendedor);
        }

        public static void Eliminar(int id)
        {
            DAO.VendedoresDAO.Delete(id);
        }
    }
}