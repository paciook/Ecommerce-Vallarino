using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.Business
{
    public static class VentasDetalle
    {
        public static List<VentasDetalleDTO> ConsultarTodos()
        {
            return DAO.VentasDetalleDAO.ReadAll("");
        }

        //public static List<VentasDetalleDTO> ConsultarPorNombre(string filtro)
        //{
        //    filtro = filtro.Replace("'", "");
        //    return DAO.VentasDetalleDAO.ReadAll("WHERE Nombre LIKE '%" + filtro + "%'");
        //}

        public static VentasDetalleDTO ConsultarPorId(int id)
        {
            var list = DAO.VentasDetalleDAO.ReadAll("WHERE ID = " + id.ToString());
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public static void Actualizar(VentasDetalleDTO venta)
        {
            DAO.VentasDetalleDAO.Update(venta);
        }

        public static void Crear(VentasDetalleDTO venta)
        {
            DAO.VentasDetalleDAO.Create(venta);
        }

        public static void Eliminar(int id)
        {
            // Tras horas de analicis llegué a la conclusión de que el id siempre va a llegar
            // a esta instancia siendo un entero, de otra forma el programa crashea al intentar
            // hacer la conversión (Y resolver eso no es algo que esté dentro de mi conocimiento
            // un sábado a las ocho de la mañana
            DAO.VentasDetalleDAO.Delete(id);
        }
    }
}
