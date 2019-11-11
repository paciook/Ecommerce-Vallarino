using ECommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        protected void btFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            CargarArticulos();
        }

        private void CargarArticulos()
        {
            List<ArticuloDTO> respuesta = new List<ArticuloDTO>();

            using (Service.ServiceSoapClient ws = new Service.ServiceSoapClient())
            {
                //ToDo: Reemplzar lista de Articulos "de prueba" por consulta al WebService.
                    List<ArticuloDTO> articulos = ws.BuscarArticulo(txFiltro.Text).ToList();

                    for (int i = 0; i < articulos.Count(); i++)
                    {
                        respuesta.Add(new ArticuloDTO()
                        {
                            Nombre = articulos[i].Nombre,
                            Descripcion = articulos[i].Descripcion,
                            PrecioVenta = articulos[i].PrecioVenta,
                            Stock = articulos[i].Stock,
                            Id = articulos[i].Id
                        });
                    }

                GenerarBaldozas(respuesta);
            }
        }

        private void BtAgregarAlCarrito_Click(object sender, ImageClickEventArgs e)
        {
            //Boton de "Agregar al Carrito":

            ImageButton btAdd = (ImageButton)sender;
            int id = Convert.ToInt32(btAdd.Attributes["articuloid"]);
            lbMsg.Text = "Agregar - ID: " + id.ToString();
        }

        private void GenerarBaldozas(List<ArticuloDTO> articulos)
        {
            //En base a una lista de ArticuloDTO, genero todas las baldozas.

            dvArticulos.Controls.Clear();
            foreach (ArticuloDTO articulo in articulos)
            {
                var div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "col-md-4");


                var divCard = new HtmlGenericControl("div");
                divCard.Attributes.Add("class", "card mb-4 box-shadow");


                var bt = new ImageButton();
                bt.CssClass = "img-fluid";
                bt.Attributes.Add("idarticulo", articulo.Id.ToString());
                string path = Server.MapPath("~/Articulos/");
                if (System.IO.File.Exists(path + "/id" + articulo.Id + ".png"))
                {
                    bt.ImageUrl = "../Articulos/id" + articulo.Id + ".png";
                }
                else
                {
                    bt.ImageUrl = "../Articulos/nophoto.png";
                }


                var btAdd = new ImageButton();
                btAdd.Attributes.Add("articuloid", articulo.Id.ToString());
                btAdd.ImageUrl = "../Img/cart24.png";
                btAdd.Click += BtAgregarAlCarrito_Click;


                var divBody = new HtmlGenericControl("div");
                divBody.Attributes.Add("class", "card-body");

                Label lbNombre = new Label();
                lbNombre.Attributes.Add("class", "card-text");
                lbNombre.Text = "Nombre: " + articulo.Nombre + "<br />";

                Label lbDescripcion = new Label();
                lbDescripcion.Attributes.Add("class", "card-text");
                lbDescripcion.Text = "Descripción: " + articulo.Descripcion + "<br/>";

                Label lbPrecio = new Label();
                lbPrecio.Attributes.Add("class", "card-text");
                lbPrecio.Text = "Precio: " + articulo.PrecioVenta + "<br/>";

                Label lbStock = new Label();
                lbStock.Attributes.Add("class", "card-text");
                lbStock.Text = "Stock: " + articulo.Stock + "<br/>";


                divBody.Controls.Add(bt);
                divBody.Controls.Add(lbNombre);
                divBody.Controls.Add(lbDescripcion);
                divBody.Controls.Add(lbPrecio);
                divBody.Controls.Add(lbStock);
                divBody.Controls.Add(btAdd);

                divCard.Controls.Add(divBody);
                div.Controls.Add(divCard);

                dvArticulos.Controls.Add(div);
            }
        }
    }
}