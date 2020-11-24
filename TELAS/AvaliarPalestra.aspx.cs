using System;
using System.Collections.Generic;
using System.Data;
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
                using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                {
                    string cmd = "UPDATE inscricao SET nota = @nota WHERE rgmParticipante = @RGM_Usuario and idPalestra = @Avaliando_Palestra_ID";
                    if (db.ExecUpdate(
                        cmd,
                        new SqlParameter("@nota", SqlDbType.Int) { Value = txtNota.Text },
                        new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] },
                        new SqlParameter("@Avaliando_Palestra_ID", SqlDbType.Int) { Value = Session["Avaliando_Palestra_ID"] }
                        ) > 0)
                    { }
                    else
                    {
                        alert("Falha ao adicionar Palestrante!");
                    }
                }
                Response.Redirect("MinhasPalestras.aspx");
            }
            else
            { }
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