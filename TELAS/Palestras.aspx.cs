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
    public partial class Palestras : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        public void atualizarGrid()
        {
            using (ServicosDB db = new ServicosDB())
            {
                gvPalestras.DataSource = db.ExecQuery("SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Local', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante where dataHorarioInicio > GETDATE()");
                gvPalestras.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RGM_Usuario"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            atualizarGrid();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void gvPalestras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "inscrever")
            {
                Boolean naoInscrito = false;
                Boolean inscricaoEfetuada = false;
                Boolean naoCheia = false;

                int Linha = Convert.ToInt32(e.CommandArgument);
                int idPalestraAtual = Convert.ToInt32(gvPalestras.Rows[Linha].Cells[0].Text);

                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select count(I.rgmParticipante) as contagem from inscricao as I inner join palestra as P on P.id = I.idPalestra where I.rgmParticipante = @RGM_Usuario and I.idPalestra = @idPalestraAtual";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] },
                        new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual }
                        );

                    if (dr.Read())
                    {
                        if (Convert.ToInt32(dr["contagem"]) > 0)
                        {
                            alert("Você já se inscreveu nesta Palestra!");
                        }
                        else
                        {
                            naoInscrito = true;
                        }
                    }
                    dr.Close();
                }

                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select (select count(I.rgmParticipante) from Inscricao as I INNER JOIN Palestra as P on P.id = I.idPalestra where P.id = @idPalestraAtual) as 'Inscritos', (select E.capacidade from Espaco as E INNER JOIN Palestra as P on E.id = P.idEspaco where P.id = @idPalestraAtual) as 'Capacidade'";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual });

                    if (dr.Read())
                    {
                        if (Convert.ToInt32(dr["Capacidade"]) > Convert.ToInt32(dr["Inscritos"]))
                        {
                            naoCheia = true;
                        }
                    }
                    dr.Close();
                }

                try
                {
                    if (naoInscrito && naoCheia)
                    {
                        using (ServicosDB db = new ServicosDB()) // INSERT DATABASE
                        {
                            string cmd = "insert into inscricao values(@RGM_Usuario, @idPalestraAtual, 0, -1)";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] },
                                new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual }
                                ) > 0)
                            { }
                            else
                            {
                                alert("Falha ao inscrever-se na palestra!");
                            }
                            atualizarGrid();
                        }
                        alert("Inscrição efetuada com sucesso!");
                        inscricaoEfetuada = true;
                    }
                }
                catch (Exception ignored)
                {
                    inscricaoEfetuada = false;
                }

                if (inscricaoEfetuada)
                {
                    try
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "UPDATE palestra SET inscritos = (select count(idPalestra) from inscricao where idPalestra = @idPalestraAtual) where id = @idPalestraAtual";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual }
                                ) > 0)
                            { }
                            else
                            {
                                alert("Falha ao falha ao atualizar contagem de inscritos!");
                            }
                            atualizarGrid();
                        }
                    }
                    catch (Exception ignored)
                    { }
                }
                else
                {
                    alert("Inscrição malsucedida!");
                }


            }
        }
    }
}