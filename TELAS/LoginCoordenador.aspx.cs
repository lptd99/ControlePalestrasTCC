using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class LoginCoordenador : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                String password = SHA256.Create(txtSenha.Text).ToString();
                string cmd = "select rgm, senha from coordenador where rgm = @rgm";
                SqlDataReader dr = db.ExecQuery(
                    cmd,
                    new SqlParameter("@rgm", SqlDbType.VarChar, 20) { Value = txtRGM.Text }
                    );
                if (dr.Read())
                {
                    if (Convert.ToString(dr["rgm"]) == txtRGM.Text && Convert.ToString(dr["senha"]) == ServicosDB.stringToSHA256(txtSenha.Text))
                    {
                        Session["RGM_Usuario"] = txtRGM.Text;
                        Session["Coordenador"] = true;
                        Response.Redirect("HomeCoordenador.aspx");
                    }
                    else
                    {
                        alert("RGM não cadastrado ou Senha incorreta!");
                    }
                }
                else
                {
                    alert("RGM não cadastrado ou Senha incorreta!");
                }
                dr.Close();
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