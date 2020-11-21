using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class CadastrarCoordenador : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RGM_Usuario"] == null || !Convert.ToBoolean(Session["Coordenador"]))
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnCadastrarCoord_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean newRGM = true;

                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select rgm from participante");
                while (sqlDataReader.Read())
                {
                    string rgm = "";
                    try
                    {
                        rgm = Convert.ToString(sqlDataReader["rgm"]);
                    }
                    catch (Exception ignored)
                    { }
                    if (rgm == txtRGM.Text)
                    {
                        newRGM = false;
                    }
                }
                sqlDataReader.Close();

                if (newRGM)
                {
                    if (cadastroCoordValidation())
                    {
                        SqlCommand sqlCommand = new SqlCommand(
                            $"insert into coordenador values('{txtRGM.Text}','{txtEmail.Text}','{pwdSenha.Text}','{txtNome.Text}','{txtDataNasc.Text}','{txtRG.Text}','{txtCPF.Text}')",
                            sqlConnection);

                        sqlCommand.ExecuteNonQuery();
                        Response.Write("<script>alert('Cadastro efetuado com sucesso!')</script>");
                    } else
                    {
                        Response.Write("<script>alert('Um ou mais campos estão inválidos!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Este RGM já está cadastrado!')</script>");
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                alert("Falha ao Cadastrar Coordenador. Erro: "+exception);
            }
        }

        private bool cadastroCoordValidation()
        {
            Boolean valid = true;

            // DataNasc validation
            try
            {
                String[] dataNascInfo = txtDataNasc.Text.Split('-');
                DateTime dataNasc = new DateTime(Convert.ToInt32(dataNascInfo[0]), Convert.ToInt32(dataNascInfo[1]), Convert.ToInt32(dataNascInfo[2]));
            }
            catch (Exception exception)
            {
                valid = false;
                alert("Falha ao validar Data de Nascimento. Erro: " + exception + ". Talvez não represente uma Data de Nascimento?");
            }

            // RGM validation
            try
            { Convert.ToInt64(txtRGM.Text); }
            catch
            {
                valid = false;
                alert("O campo RGM deve conter apenas números!");
            }
            if (txtRGM.Text == "" || txtRGM.Text.Length != 11)
            {
                valid = false;
                alert("RGM inválido! Deve ter 11 caracteres.");
            }

            // Senha validation
            if (pwdSenha.Text != pwdConfirma.Text || pwdSenha.Text.Length > 30)
            {
                valid = false;
                alert("Senha inválida! Ambos os campos de senha devem ser iguais e ter um máximo de 30 caracteres.");
            }

            // Nome validation
            if (txtNome.Text == "" || txtNome.Text.Length > 100)
            {
                valid = false;
                alert("Nome inválido! Não pode ser vazio nem ultrapassar 100 caracteres.");
            }

            // RG validation
            try
            { Convert.ToInt64(txtRG.Text); }
            catch
            {
                valid = false;
                alert("O campo RG deve conter apenas números!");
            }
            if (txtRG.Text == "" || txtRG.Text.Length != 9)
            {
                valid = false;
                alert("RG inválido! Deve ter 9 caracteres.");
            }

            // CPF validation
            try
            { Convert.ToInt64(txtCPF.Text); }
            catch
            {
                valid = false;
                alert("O campo CPF deve conter apenas números!");
            }
            if (txtCPF.Text == "" || txtCPF.Text.Length != 11)
            {
                valid = false;
                alert("CPF inválido! Deve ter 11 caracteres.");
            }

            return valid;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginCoordenador.aspx");
        }
    }
}