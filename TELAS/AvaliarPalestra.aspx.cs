using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class AvaliarPalestra : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RGM_Usuario"] != null && Session["Avaliando_Palestra_ID"] != null && Session["Avaliando_Palestra_Nome"] != null)
            {
                txtRGM.Text = Session["RGM_Usuario"].ToString();
                txtID.Text = Session["Avaliando_Palestra_ID"].ToString();
                txtNome.Text = Session["Avaliando_Palestra_Nome"].ToString();
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnAvaliar_Click(object sender, EventArgs e)
        {
            if (notaIsValid())
            {
                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlCommand sqlCommand = new SqlCommand(
                    $"UPDATE inscricao SET nota = {txtNota.Text} WHERE rgmParticipante = '{Session["RGM_Usuario"]}' and idPalestra = {Session["Avaliando_Palestra_ID"]}",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Response.Redirect("MinhasPalestras.aspx");
            }
            else
            {
            }
        }

        private bool notaIsValid()
        {
            int nota = -1;
            try
            {
                nota = Convert.ToInt32(txtNota.Text);
            }
            catch
            {
                alert("A nota deve ser um número inteiro!");
            }
            if(
                nota >= 0 && nota <= 10
                )
            {
                return true;
            }
            else
            {
                alert("A nota deve ser de 0 a 10.");
                return false;
            }
        }
    }
}