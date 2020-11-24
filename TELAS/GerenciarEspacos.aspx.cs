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

            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select id from espaco where id = @id";
                SqlDataReader dr = db.ExecQuery(
                    cmd,
                    new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text });

                if (dr.Read())
                {
                    try
                    {
                        id = Convert.ToInt32(dr["id"]);
                    }
                    catch
                    {
                        id = -1;
                    }
                }
                else
                {
                    id = -1;
                }
                dr.Close();
            }

            if (
                id == -1
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
        private bool cadastroEspacoValidationINSERT()
        {
            Boolean valid = true;
            int id = -1;

            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select id from espaco where id = @id";
                SqlDataReader dr = db.ExecQuery(
                    cmd,
                    new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text });

                if (dr.Read())
                {
                    try
                    {
                        id = Convert.ToInt32(dr["id"]);
                    }
                    catch
                    {
                        id = -1;
                    }
                }
                else
                {
                    id = -1;
                }
                dr.Close();
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
            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select max(id) as lastID from espaco";
                SqlDataReader dr = db.ExecQuery(cmd);

                if (dr.Read())
                {
                    try
                    {
                        nextID = Convert.ToInt32(dr["lastID"]) + 1;
                    }
                    catch
                    {
                        nextID = 0;
                    }
                }
                dr.Close();
            }
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
            using (ServicosDB db = new ServicosDB())
            {
                gvEspacos.DataSource = db.ExecQuery($"SELECT [id], [nome], [capacidade] FROM [Espaco]");
                gvEspacos.DataBind();
            }
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
            //try {
                if (cadastroEspacoValidationINSERT())
                {
                    using (ServicosDB db = new ServicosDB()) // INSERT DATABASE
                    {
                        string cmd = "insert into espaco values(@nome, @capacidade)";
                        if (db.ExecUpdate(
                            cmd,
                            new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                            new SqlParameter("@capacidade", SqlDbType.Int) { Value = txtCapacidade.Text }
                            ) > 0)
                        { }
                        else
                        {
                            alert("Falha ao adicionar Palestrante!");
                        }
                        atualizarGrid();
                    }
                }
                else
                {
                    alert("Um ou mais campos estão inválidos!");
                }
                atualizarGrid();
                limparCampos();
            //} catch (Exception exception) { alert("Falha ao Adicionar Espaço. Erro: " + exception); }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            //try {
                if (Convert.ToInt32(txtID.Text) < getNextID())
                {
                    using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                    {
                        if (cadastroEspacoValidation())
                        {
                            string cmd = "UPDATE espaco SET nome = @nome, capacidade = @capacidade where id = @id";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                                new SqlParameter("@capacidade", SqlDbType.Int) { Value = txtCapacidade.Text },
                                new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text }
                                ) > 0)
                            { }
                        }
                        else
                        {
                            alert("Falha ao adicionar Espaço!");
                        }
                        atualizarGrid();
                    }
                }
                else
                {
                    alert("Carregue um Espaço primeiro!");
                }
                limparCampos();
                atualizarGrid();
            //} catch (Exception exception) { alert("Falha ao Alterar Espaço. Erro: " + exception); }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //try {
                if (Convert.ToInt32(txtID.Text) < getNextID())
                {
                    using (ServicosDB db = new ServicosDB()) // DELETE DATABASE
                    {
                        string cmd = "delete from espaco where id = @id";
                        if (db.ExecUpdate(
                            cmd,
                            new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text }
                            ) > 0)
                        {
                            limparCampos();
                        }
                        else
                        {
                            alert("Falha ao excluir Espaço!");
                        }
                        atualizarGrid();
                    }
                }
                else
                {
                    alert("Carregue um Espaço primeiro!");
                }
                limparCampos();
                atualizarGrid();
            //} catch (Exception exception) { alert("Falha ao Excluir Espaço. Erro: " + exception.ToString() + ". Talvez este espaço esteja ocupado por alguma palestra?"); }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeCoordenador.aspx");
        }

        protected void gvEspacos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "carregar")
            {
                //try {
                    int Linha = Convert.ToInt32(e.CommandArgument);
                    int idEspacoAtual = Convert.ToInt32(gvEspacos.Rows[Linha].Cells[0].Text);

                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select * from espaco where id = @id";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@id", SqlDbType.Int) { Value = idEspacoAtual }
                            );

                        if (dr.Read())
                        {
                            txtID.Text = Convert.ToString(dr["id"]);
                            txtNome.Text = Convert.ToString(dr["nome"]);
                            txtCapacidade.Text = Convert.ToString(dr["capacidade"]);
                        }
                        dr.Close();
                    }
                //} catch (Exception exception) { alert("Falha ao Carregar Espaço. Erro: " + exception.ToString()); }
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}