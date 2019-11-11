using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentasCapas.DTO;

namespace VentasCapas.Business
{
    public static class Articulos
    {
        public static List<ArticuloDTO> ConsultarTodos()
        {
            return DAO.ArticuloDAO.ReadAll("");
        }

        public static List<ArticuloDTO> ConsultarPorNombre(string filtro)
        {
            filtro = filtro.Replace("'", "");
            return DAO.ArticuloDAO.ReadAll("WHERE Nombre LIKE '%" + filtro + "%'");
        }

        public static ArticuloDTO ConsultarPorId(int id)
        {
            var list = DAO.ArticuloDAO.ReadAll("WHERE ID = " + id.ToString());
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public static void Actualizar(ArticuloDTO articulo)
        {
            DAO.ArticuloDAO.Update(articulo);
        }

        public static void Crear(ArticuloDTO articulo)
        {
            DAO.ArticuloDAO.Create(articulo);
        }

        public static void Eliminar(int id)
        {
            // Tras horas de analicis llegué a la conclusión de que el id siempre va a llegar
            // a esta instancia siendo un entero, de otra forma el programa crashea al intentar
            // hacer la conversión (Y resolver eso no es algo que esté dentro de mi conocimiento
            // un sábado a las ocho de la mañana
            DAO.ArticuloDAO.Delete(id);
        }
    }
}
