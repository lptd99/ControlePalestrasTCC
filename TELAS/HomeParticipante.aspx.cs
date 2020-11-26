using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class HomeParticipante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["RGM_Usuario"] == null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["RGM_Usuario"] = null;
            Response.Redirect("LoginParticipante.aspx");
        }

        protected void btnPalestras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Palestras.aspx");
        }

        protected void btnMinhasPalestras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinhasPalestras.aspx");
        }

        protected void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterarSenhaParticipante.aspx");
        }
    }
}