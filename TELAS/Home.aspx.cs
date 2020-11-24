using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select count(rgm) as contagem from coordenador";
                SqlDataReader dr = db.ExecQuery(
                    cmd
                    );

                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["contagem"]) == 0)
                    {
                        Session["CadastrarPrimeiroCoordenador"] = true;
                        Response.Redirect("CadastrarCoordenador.aspx");
                    }
                }
                dr.Close();
            }

            if(Session["RGM_Usuario"] != null)
            {
                if (Convert.ToBoolean(Session["Coordenador"]))
                {
                    Response.Redirect("HomeCoordenador.aspx");
                }
                else
                {
                    Response.Redirect("HomeParticipante.aspx");
                }
            }
        }

        protected void btnLoginCoordenador_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginCoordenador.aspx");
        }

        protected void btnLoginParticipante_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginParticipante.aspx");
        }
    }
}