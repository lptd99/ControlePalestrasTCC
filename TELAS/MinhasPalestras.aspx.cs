using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class MinhasPalestras : System.Web.UI.Page
    {
        private void atualizarGrid()
        {
            gvMinhasPalestras.DataSource = gvMinhasPalestrasDataSource;
            gvMinhasPalestras.DataBind();
        }
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvMinhasPalestrasDataSource.SelectCommand = $"SELECT[P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Sala', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante INNER JOIN [Inscricao] as I on P.id = I.idPalestra where I.rgmParticipante = '{Session["RGM_Usuario"]}'";
            atualizarGrid();
            if (Session["RGM_Usuario"] == null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }


        protected void gvMinhasPalestras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "avaliar")
            {
                int Linha = Convert.ToInt32(e.CommandArgument);
                int idPalestraAtual = Convert.ToInt32(gvMinhasPalestras.Rows[Linha].Cells[0].Text);
                string nomePalestraAtual = Convert.ToString(gvMinhasPalestras.Rows[Linha].Cells[1].Text);

                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select presente, nota from inscricao where rgmParticipante = {Session["RGM_Usuario"]} and idPalestra = {idPalestraAtual}");
                while (sqlDataReader.Read())
                {
                    try
                    {
                        if (Convert.ToBoolean(sqlDataReader["presente"]))
                        {
                            if (Convert.ToInt32(sqlDataReader["nota"]) == -1)
                            {
                                Session["Avaliando_Palestra_ID"] = idPalestraAtual;
                                Session["Avaliando_Palestra_Nome"] = nomePalestraAtual;
                                Response.Redirect("AvaliarPalestra.aspx");
                            }
                            else
                            {
                                alert("Você já avaliou esta palestra!");
                            }
                        }
                        else
                        {
                            alert("Você não compareceu a esta Palestra!");
                        }
                    }
                    catch (Exception ignored)
                    {
                        alert("Você não compareceu a esta Palestra!");
                    }
                }
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            else if (e.CommandName == "emitirCertificado")
            {

            }
        }

    }
}