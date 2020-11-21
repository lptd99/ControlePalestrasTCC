using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class LoginCoordenador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

            Boolean existingRGM = false;

            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");

            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select rgm from coordenador");

            while (sqlDataReader.Read())
            {
                string rgm = "";
                try
                {
                    rgm = Convert.ToString(sqlDataReader["rgm"]);
                }
                catch (Exception ignored)
                { }
                if (rgm == txtRGM.Text)
                {
                    existingRGM = true;
                }
            }
            sqlDataReader.Close();

            if (existingRGM)
            {
                SqlDataReader sqlDataReader1 = ServicosDB.createSQLCommandReader(sqlConnection, $"select senha from coordenador where rgm = '{txtRGM.Text}'");
                sqlDataReader1.Read();
                if (txtSenha.Text == Convert.ToString(sqlDataReader1["senha"]))
                {
                    Session["RGM_Usuario"] = txtRGM.Text;
                    Session["Coordenador"] = true;
                    Response.Redirect("HomeCoordenador.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Este RGM nunca foi cadastrado!')</script>");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarCoordenador.aspx");
        }

        protected void btnEsqueciMinhaSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("EsqueciASenha.aspx");
        }
    }
}