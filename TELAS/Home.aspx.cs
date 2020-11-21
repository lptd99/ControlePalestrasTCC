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
            int contagem = 0;
            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select count(rgm) as contagem from coordenador");
            while (sqlDataReader.Read())
            {
                try
                {
                    contagem = Convert.ToInt32(sqlDataReader["contagem"]);
                }
                catch (Exception ignored)
                { }

                if (contagem == 0)
                {
                    Response.Redirect("CadastrarCoordenador.aspx");
                }
            }
            sqlDataReader.Close();

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