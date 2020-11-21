using System;
using System.Collections.Generic;
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
            gvPalestras.DataSource = gvPalestrasDataSource;
            gvPalestras.DataBind();
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
                Boolean podeInscrever = false;
                Boolean inscrito = false;

                int Linha = Convert.ToInt32(e.CommandArgument);
                int idPalestraAtual = Convert.ToInt32(gvPalestras.Rows[Linha].Cells[0].Text);

                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select count(I.rgmParticipante) as contagem from inscricao as I inner join palestra as P on P.id = I.idPalestra where I.rgmParticipante = '{Session["RGM_Usuario"]}' and I.idPalestra = {idPalestraAtual}");
                while (sqlDataReader.Read())
                {
                    if (Convert.ToInt32(sqlDataReader["contagem"]) > 0)
                    {
                        alert("Você já se inscreveu nesta Palestra!");
                    }
                    else
                    {
                        podeInscrever = true;
                    }
                }
                sqlDataReader.Close();

                try
                {
                    if (podeInscrever)
                    {
                        SqlCommand sqlCommand = new SqlCommand(
                            $"insert into inscricao values('{Session["RGM_Usuario"]}', {idPalestraAtual}, 0, -1)",
                            sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        alert("Inscrição efetuada com sucesso!");
                        inscrito = true;
                    }
                }
                catch (Exception ignored)
                {
                    alert("Inscrição malsucedida!");
                    inscrito = false;
                }

                try
                {
                    if (inscrito)
                    {
                        SqlCommand sqlCommand = new SqlCommand(
                            $"UPDATE palestra SET inscritos = (select count(idPalestra) from inscricao where idPalestra = {idPalestraAtual}) where id = {idPalestraAtual}",
                        sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ignored)
                { }

                sqlConnection.Close();
                atualizarGrid();
            }
        }
    }
}