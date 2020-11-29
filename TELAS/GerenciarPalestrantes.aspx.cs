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

            // validating CPF's uniqueness
            if (valid)
            {
                int primeiroDigito = txtCPF.Text[9] - 48;
                Boolean primeiroDigitoOK = false;
                int segundoDigito = txtCPF.Text[10] - 48;
                Boolean segundoDigitoOK = false;
                int[] digitosCPF = {
                    txtCPF.Text[0]-48, txtCPF.Text[1]-48, txtCPF.Text[2]-48, txtCPF.Text[3]-48,
                    txtCPF.Text[4]-48, txtCPF.Text[5]-48, txtCPF.Text[6]-48, txtCPF.Text[7]-48,
                    txtCPF.Text[8]-48, txtCPF.Text[9]-48, txtCPF.Text[10]-48
                };
                int resultado = 0;
                for (int i = 2; i < digitosCPF.Length; i++)
                {
                    resultado += digitosCPF[i - 2] * (12 - i);
                }

                if (resultado * 10 % 11 == 10) { primeiroDigitoOK = primeiroDigito == 0; }
                else { primeiroDigitoOK = primeiroDigito == resultado * 10 % 11; }

                if (primeiroDigitoOK)
                {
                    resultado = 0;
                    for (int i = 1; i < digitosCPF.Length; i++)
                    {
                        resultado += digitosCPF[i - 1] * (12 - i);
                    }
                }

                if (resultado * 10 % 11 == 10) { segundoDigitoOK = segundoDigito == 0; }
                else { segundoDigitoOK = segundoDigito == resultado * 10 % 11; }

                if (!primeiroDigitoOK || !segundoDigitoOK)
                {
                    valid = false;
                    alert("CPF inválido!");
                }
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

            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select id from palestrante where id = @id";
                SqlDataReader dr = db.ExecQuery(
                    cmd,
                    new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text });

                if (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]);
                }
                else
                {
                    id = -1;
                }
                dr.Close();
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
            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select max(id) as lastID from palestrante";
                SqlDataReader dr = db.ExecQuery(
                    cmd
                    );

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
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtFormacao.Text = "";
        }

        private void atualizarGrid()
        {
            using (ServicosDB db = new ServicosDB())
            {
                gvPalestrantes.DataSource = db.ExecQuery($"SELECT [id], [nome], [email], [telefone], [formacao] FROM [Palestrante]");
                gvPalestrantes.DataBind();
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
            try
            {
                Boolean newRG = true;
                Boolean newCPF = true;
                string rg = "";
                string cpf = "";
                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select rg from palestrante where rg = @rg";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@rg", SqlDbType.VarChar, 9) { Value = txtRG.Text });

                    if (dr.Read())
                    {
                        rg = Convert.ToString(dr["rg"]);
                    }
                    dr.Close();
                }
                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select cpf from palestrante where cpf = @cpf";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@cpf", SqlDbType.VarChar, 11) { Value = txtCPF.Text });

                    if (dr.Read())
                    {
                        cpf = Convert.ToString(dr["cpf"]);
                    }
                    dr.Close();
                }
                if (rg == txtRG.Text)
                {
                    newRG = false;
                }
                if (cpf == txtCPF.Text)
                {
                    newCPF = false;
                }

                if (newRG && newCPF)
                {
                    if (cadastroPalestranteFullValidation())
                    {
                        using (ServicosDB db = new ServicosDB())
                        {
                            string cmd = "insert into palestrante values(@nome, @rg, @cpf, @email, @telefone, @formacao)";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                                new SqlParameter("@rg", SqlDbType.VarChar, 9) { Value = txtRG.Text },
                                new SqlParameter("@cpf", SqlDbType.VarChar, 11) { Value = txtCPF.Text },
                                new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = txtEmail.Text },
                                new SqlParameter("@telefone", SqlDbType.VarChar, 20) { Value = txtTelefone.Text },
                                new SqlParameter("@formacao", SqlDbType.VarChar, 100) { Value = txtFormacao.Text }
                                ) > 0)
                            {
                                int id = Convert.ToInt32(db.QueryValue("select @@identity"));
                                txtID.Text = $"{id}";
                                limparCampos();
                            }
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
                }
                else
                {
                    alert("RG ou CPF já cadastrados ou inválidos!");
                }
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
                    if (cadastroPalestranteValidateCampos())
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "UPDATE palestrante SET nome = @nome, rg = @rg, cpf = @cpf, email = @email, telefone = @telefone, formacao = @formacao where id = @id";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                                new SqlParameter("@rg", SqlDbType.VarChar, 9) { Value = txtRG.Text },
                                new SqlParameter("@cpf", SqlDbType.VarChar, 11) { Value = txtCPF.Text },
                                new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = txtEmail.Text },
                                new SqlParameter("@telefone", SqlDbType.VarChar, 20) { Value = txtTelefone.Text },
                                new SqlParameter("@formacao", SqlDbType.VarChar, 100) { Value = txtFormacao.Text },
                                new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text }
                                ) > 0)
                            { 
                                limparCampos();
                            }
                            else
                            {
                                alert("Falha ao alterar Palestrante!");
                            }
                        }
                    }
                    else
                    {
                        alert("Um ou mais campos inválidos!");
                    }
                }
                else
                {
                    alert("Carregue um Palestrante primeiro!");
                }
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
                    using (ServicosDB db = new ServicosDB()) // DELETE DATABASE
                    {
                        string cmd = "delete from palestrante where id = @id";
                        if (db.ExecUpdate(
                            cmd,
                            new SqlParameter("@id", SqlDbType.Int) { Value = txtID.Text }
                            ) > 0)
                        {
                            limparCampos();
                        }
                        else
                        {
                            alert("Falha ao excluir Palestrante!");
                        }
                        atualizarGrid();
                    }
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

                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select * from palestrante where id = @idPalestranteAtual";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@idPalestranteAtual", SqlDbType.Int) { Value = idPalestranteAtual }
                            );

                        if (dr.Read())
                        {
                            txtID.Text = Convert.ToString(dr["id"]);
                            txtNome.Text = Convert.ToString(dr["nome"]);
                            txtRG.Text = Convert.ToString(dr["rg"]);
                            txtCPF.Text = Convert.ToString(dr["cpf"]);
                            txtEmail.Text = Convert.ToString(dr["email"]);
                            txtTelefone.Text = Convert.ToString(dr["telefone"]);
                            txtFormacao.Text = Convert.ToString(dr["formacao"]);
                        }
                        dr.Close();
                    }
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