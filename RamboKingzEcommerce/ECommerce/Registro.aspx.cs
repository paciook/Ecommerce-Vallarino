using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Registro : System.Web.UI.Page
    {
        Service.ServiceSoapClient ws = new ServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txUsuario.Text)
                    || string.IsNullOrWhiteSpace(txContraseña.Text)
                    || string.IsNullOrWhiteSpace(txDireccion.Text)
                    || string.IsNullOrWhiteSpace(txEmail.Text)
                    || string.IsNullOrWhiteSpace(txNombre.Text)
                    || string.IsNullOrWhiteSpace(txTelefono.Text))
                {
                    lbMsg.Text = "Por favor complete todos los campos.";
                    return;
                }

                ClientesDTO cliente = new ClientesDTO();
                cliente.Usuario = txUsuario.Text;
                cliente.Contraseña = txContraseña.Text;
                cliente.Direccion = txDireccion.Text;
                cliente.Email = txEmail.Text;
                cliente.Nombre = txNombre.Text;
                cliente.Telefono = txTelefono.Text;
                cliente = ws.CrearCuenta(cliente);

                if (cliente != null)
                {
                    cliente.Nombre = txUsuario.Text;
                    Session.Add("cliente", cliente);
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    lbMsg.Text = "Revise los datos ingresados.";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }
    }
}