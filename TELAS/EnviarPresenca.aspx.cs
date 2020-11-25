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
    public partial class EnviarPresenca : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (
                Convert.ToString(Session["RGM_Usuario"]) == null ||
                Convert.ToBoolean(Session["Coordenador"]) != true ||
                Convert.ToString(Session["Enviar_Presenca_Palestra_Nome"]) == null
                )
            {
                Response.Redirect("HomeCoordenador.aspx");
            }
            else
            {
                txtID.Text = Convert.ToString(Session["Enviar_Presenca_Palestra_ID"]);
                txtNome.Text = Convert.ToString(Session["Enviar_Presenca_Palestra_Nome"]);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int sucesso = 0;
            int erro = 0;
            String presentesErro = "";
            String presentes = txtPresentes.Text;
            String[] presentesList = presentes.Replace("\r\n", "Ñ").Split('Ñ');
            for(int i = 0; i < presentesList.Length; i++)
            {
                try
                {
                    Convert.ToInt64(presentesList[i]);
                    if (presentesList[i] == "" || presentesList[i].Length != 11)
                    {
                        erro++;
                        if (presentesErro.Contains("\""))
                        {
                            presentesErro = presentesErro + ",";
                        }
                        presentesErro = presentesErro + " \"" + presentesList[i] + "\"";
                    }
                    else
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "UPDATE inscricao SET presente = 1 where idPalestra = @idPalestraAtual and rgmParticipante = @rgmParticipante";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = txtID.Text },
                                new SqlParameter("@rgmParticipante", SqlDbType.VarChar, 11) { Value = presentesList[i] }
                                ) > 0)
                            { }
                            else
                            {
                                erro++;
                                if (presentesErro.Contains("\""))
                                {
                                    presentesErro = presentesErro + ",";
                                }
                                presentesErro = presentesErro + " \"" + presentesList[i] + "\"";
                                alert("Falha ao salvar presença!");
                            }
                        }
                        sucesso ++;
                    }
                }
                catch
                {
                    erro ++;
                    if (presentesErro.Contains("\""))
                    {
                        presentesErro = presentesErro + ",";
                    }
                    presentesErro = presentesErro + " \"" + presentesList[i] + "\"";
                }
            }
            alert("As seguintes linhas não foram identificadas como RGMs válidos:" + presentesErro);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["Enviar_Presenca_Palestra_ID"] = null;
            Session["Enviar_Presenca_Palestra_Nome"] = null;
            Response.Redirect("HomeCoordenador.aspx");
        }
    }
}