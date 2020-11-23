using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class GerenciarPalestrantes : System.Web.UI.Page
    {
        #region Variaveis
        int nextID = 0;
        #endregion

        #region Metodos auxiliares
        private bool cadastroPalestranteValidateCampos()
        {
            Boolean valid = true;
            // VALIDATE NOME
            if (
                txtNome.Text == "" || txtNome.Text.Length > 100
                )
            {
                valid = false;
                alert("O campo Nome não pode ser vazio nem ultrapassar 100 caracteres.");
            }
            // VALIDATE RG
            try
            {
                Convert.ToInt64(txtRG.Text);
            }
            catch
            {
                valid = false;
                alert("O campo RG deve conter apenas números!");
            }
            if (
                txtRG.Text == "" || txtRG.Text.Length != 9
                )
            {
                valid = false;
                alert("O campo RG não pode ser vazio e deve ter 9 caracteres.");
            }
            // VALIDATE CPF
            try
            {
                Convert.ToInt64(txtCPF.Text);
            }
            catch
            {
                valid = false;
                alert("O campo CPF deve conter apenas números!");
            }
            if (
                txtCPF.Text == "" || txtCPF.Text.Length != 11
                )
            {
                valid = false;
                alert("O campo CPF não pode ser vazio e deve ter 11 caracteres.");
            }
            // VALIDATE EMAIL
            if (
                txtEmail.Text == "" || txtEmail.Text.Length > 100
                )
            {
                valid = false;
                alert("O campo E-mail não pode ser vazio nem ultrapassar 100 caracteres.");
            }
            // VALIDATE TELEFONE
            try
            {
                Convert.ToInt64(txtTelefone.Text);
            }
            catch
            {
                valid = false;
                alert("O campo Telefone deve conter apenas números!");
            }
            if (
                txtTelefone.Text == "" || txtTelefone.Text.Length > 18
                )
            {
                valid = false;
                alert("O campo Telefone não pode ser vazio nem ultrapassar 18 caracteres.");
            }
            // VALIDATE FORMACAO
            if (
                txtFormacao.Text == "" || txtFormacao.Text.Length > 100
                )
            {
                valid = false;
                alert("O campo Formação não pode ser vazio nem ultrapassar 100 caracteres.");
            }
            return valid;
        }
        private bool cadastroPalestranteFullValidation()
        {
            Boolean valid = true;
            int id = -1;

            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select id as id from palestrante where id = {txtID.Text}");
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

            // VALIDATE ID
            if (
                id != -1
                )
            {
                valid = false;
                alert("Este ID já está cadastrado! Tente recarregar a página ou apertar o botão Limpar.");
            }
            
            if(valid)
            {
                valid = cadastroPalestranteValidateCampos();
            }

            return valid;
        }

        public int getNextID()
        {
            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select max(id) as lastID from palestrante");
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
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtFormacao.Text = "";
        }

        private void atualizarGrid()
        {
            gvPalestrantes.DataSource = gvPalestrantesDataSource;
            gvPalestrantes.DataBind();
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
                Boolean newRG = true;
                Boolean newCPF = true;

                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select rg, cpf from palestrante");
                while (sqlDataReader.Read())
                {
                    string rg = "";
                    string cpf = "";
                    try
                    {
                        rg = Convert.ToString(sqlDataReader["rg"]);
                        cpf = Convert.ToString(sqlDataReader["cpf"]);
                    }
                    catch (Exception ignored)
                    { }
                    if (rg == txtRG.Text)
                    {
                        newRG = false;
                    }
                    if (cpf == txtCPF.Text)
                    {
                        newCPF = false;
                    }
                }
                sqlDataReader.Close();

                if (newRG && newCPF)
                {
                    if (cadastroPalestranteFullValidation())
                    {
                        SqlCommand sqlCommand = new SqlCommand(
                            $"insert into palestrante values('{txtNome.Text}','{txtRG.Text}','{txtCPF.Text}','{txtEmail.Text}','{txtTelefone.Text}','{txtFormacao.Text}')",
                            sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        limparCampos();
                    }
                    else
                    {
                        alert("Um ou mais campos estão inválidos!");
                    }
                }
                else
                {
                    alert("RG ou CPF já cadastrado!");
                }
                sqlConnection.Close();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Adicionar Palestrante. Erro: " + exception);
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
                        $"UPDATE palestrante SET nome = '{txtNome.Text}', rg = '{txtRG.Text}', cpf = '{txtCPF.Text}', email = '{txtEmail.Text}', telefone = '{txtTelefone.Text}', formacao = '{txtFormacao.Text}' WHERE id = {txtID.Text}",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    alert("Carregue um Palestrante primeiro!");
                }
                limparCampos();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Alterar Palestrante. Erro: " + exception);
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
                        $"DELETE FROM palestrante WHERE id = {txtID.Text}",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    alert("Carregue um Palestrante primeiro!");
                }
                limparCampos();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Excluir Palestrante. Erro: " + exception);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeCoordenador.aspx");
        }

        protected void gvPalestrantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "carregar")
            {
                try
                {
                    int Linha = Convert.ToInt32(e.CommandArgument);
                    int idPalestranteAtual = Convert.ToInt32(gvPalestrantes.Rows[Linha].Cells[0].Text);

                    SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                    SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select * from palestrante where id = {idPalestranteAtual}");
                    while (sqlDataReader.Read())
                    {
                        txtID.Text = Convert.ToString(sqlDataReader["id"]);
                        txtNome.Text = Convert.ToString(sqlDataReader["nome"]);
                        txtRG.Text = Convert.ToString(sqlDataReader["rg"]);
                        txtCPF.Text = Convert.ToString(sqlDataReader["cpf"]);
                        txtEmail.Text = Convert.ToString(sqlDataReader["email"]);
                        txtTelefone.Text = Convert.ToString(sqlDataReader["telefone"]);
                        txtFormacao.Text = Convert.ToString(sqlDataReader["formacao"]);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    alert("Falha ao Carregar Palestrante. Erro: " + exception);
                }
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}