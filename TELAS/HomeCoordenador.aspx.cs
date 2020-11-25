using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class HomeCoordenador : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RGM_Usuario"] == null || !Convert.ToBoolean(Session["Coordenador"]))
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["RGM_Usuario"] = null;
            Session["Coordenador"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void btnGerenciarPalestras_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarPalestras.aspx");
        }

        protected void btnGerenciarEspacos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarEspacos.aspx");
        }

        protected void btnGerenciarPalestrantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarPalestrantes.aspx");
        }
        protected void btnCadastrarCoordenador_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarCoordenador.aspx");
        }
    }
}