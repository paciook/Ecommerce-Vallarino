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
        public List<ArticuloDTO> GetArticulos()
        {
            return ArticuloDAO.ReadAll("");
        }

        [WebMethod]
        public ClienteDTO Login(string usuario, string contraseña)
        {
            List<ClienteDTO> lista = new List<ClienteDTO>();
            lista = ClienteDAO.ReadAll();
        }
    }
}
