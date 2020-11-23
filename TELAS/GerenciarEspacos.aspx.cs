using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class GerenciarEspacos : System.Web.UI.Page
    {
        #region Variaveis
        int nextID = 0;
        #endregion

        #region Metodos auxiliares
        private bool cadastroEspacoValidation()
        {
            Boolean valid = true;
            int id = -1;
            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select id as id from espaco where id = {txtID.Text}");
            while (sqlDataReader.Read())
            {
                try
                {
                    id = Convert.ToInt32(sqlDataReader["id"]);
                }
                catch (Exception ignored)
                {
                    id = -1;
                }
            }

            if (
                id != -1
                )
            {
                valid = false;
                alert("ID inválido! Tente apertar o botão Limpar ou recarregar a página.");
            }
            // VALIDATE Nome
            if (txtNome.Text == "" || txtNome.Text.Length > 100)
            {
                valid = false;
                alert("O campo Nome não pode ser vazio nem ultrapassar os 100 caracteres!");
            }
            // VALIDATE Capacidade
            try
            {
                Convert.ToInt32(txtCapacidade.Text);
            }
            catch
            {
                valid = false;
                alert("O campo Capacidade deve conter apenas números!");
            }
            if (txtCapacidade.Text == "" || txtCapacidade.Text.Length > 9)
            {
                valid = false;
                alert("O campo Capacidade não pode ser vazio nem ultrapassar 9 caracteres!");
            }

            return valid;
        }
        public int getNextID()
        {
            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select max(id) as lastID from espaco");
            while (sqlDataReader.Read())
            {
                try
                {
                    nextID = Convert.ToInt32(sqlDataReader["lastID"]) + 1;
                }
                catch (Exception ignored)
                {
                    nextID = 0;
                }
            }
            sqlDataReader.Close();
            return nextID;
        }
        public void limparCampos()
        {
            txtID.Text = Convert.ToString(getNextID());
            txtNome.Text = "";
            txtCapacidade.Text = "";
        }
        private void atualizarGrid()
        {
            gvEspacos.DataSource = gvEspacosDataSource;
            gvEspacos.DataBind();
        }
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RGM_Usuario"] == null || !Convert.ToBoolean(Session["Coordenador"]))
            {
                Response.Redirect("Home.aspx");
            }

            if (!IsPostBack)
            {
                limparCampos();
                atualizarGrid();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                if (cadastroEspacoValidation())
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        $"insert into espaco values('{txtNome.Text}', {txtCapacidade.Text})",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    alert("Um ou mais campos estão inválidos!");
                }
                sqlConnection.Close();
                atualizarGrid();
                limparCampos();
            }
            catch (Exception exception)
            {
                alert("Falha ao Adicionar Espaço. Erro: " + exception);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtID.Text) < getNextID())
                {
                    SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                    SqlCommand sqlCommand = new SqlCommand(
                        $"UPDATE espaco SET nome = '{txtNome.Text}', capacidade = {txtCapacidade.Text} WHERE id = {txtID.Text}",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    alert("Carregue um Espaço primeiro!");
                }
                limparCampos();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Alterar Espaço. Erro: " + exception);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtID.Text) < getNextID())
                {
                    SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                    SqlCommand sqlCommand = new SqlCommand(
                        $"DELETE FROM espaco WHERE id = {txtID.Text}",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    alert("Carregue um Espaço primeiro!");
                }
                limparCampos();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Excluir Espaço. Erro: " + exception + ". Talvez este espaço esteja ocupado por alguma palestra?");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeCoordenador.aspx");
        }

        protected void gvEspacos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "carregar")
            {
                try
                {
                    int Linha = Convert.ToInt32(e.CommandArgument);
                    int idEspacoAtual = Convert.ToInt32(gvEspacos.Rows[Linha].Cells[0].Text);

                    SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                    SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select * from espaco where id = {idEspacoAtual}");
                    while (sqlDataReader.Read())
                    {
                        txtID.Text = Convert.ToString(sqlDataReader["id"]);
                        txtNome.Text = Convert.ToString(sqlDataReader["nome"]);
                        txtCapacidade.Text = Convert.ToString(sqlDataReader["capacidade"]);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    alert("Falha ao Carregar Espaço. Erro: " + exception);
                }
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}