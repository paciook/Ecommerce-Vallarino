using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VentasCapas.DAO;
using VentasCapas.DTO;

namespace VentasCapasService
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://ventasservice.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<ArticuloDTO> GetArticulos() // Funciona
        {
            return ArticuloDAO.ReadAll("");
        }

        [WebMethod]
        public ClientesDTO Login(string usuario, string contraseña)
        {
            return new ClientesDTO();
        }

        [WebMethod]
        public ClientesDTO IniciarSesion(string usuario, string contraseña) //Funciona
        {
            var usuarios = VentasCapas.DAO.ClientesDAO.ReadAll(
                "WHERE Usuario='[usuario]' AND Contraseña='[contraseña]'"
                .Replace("[usuario]", usuario)
                .Replace("[contraseña]", contraseña));

            if (usuarios.Count > 0)
                return usuarios[0];

            return null;
        }

        [WebMethod]
        public List<ArticuloDTO> BuscarArticulo(string articulo) //Funciona
        {
            var where = "";

            if (articulo.Trim() != "")
            {
            
                where = "WHERE Nombre='[articulo]'".Replace("[articulo]", articulo);
            
            }
            
            var articulos = VentasCapas.DAO.ArticuloDAO.ReadAll(where);

            if (articulos.Count > 0)
                return articulos;

            return null;
            
        }

        [WebMethod]
        public ClientesDTO CrearCuenta(ClientesDTO cliente)
        {
            var usuario = VentasCapas.DAO.ClientesDAO.Create(cliente);

            return usuario;
        }
    }
}
