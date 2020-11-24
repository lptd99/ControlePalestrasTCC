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
    public partial class CadastrarCoordenador : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["CadastrarPrimeiroCoordenador"]))
            {
                if (Session["RGM_Usuario"] == null || !Convert.ToBoolean(Session["Coordenador"]))
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void btnCadastrarCoord_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean newRGM = true;

                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select count(rgm) as contagem from coordenador where rgm = @rgm";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@rgm", SqlDbType.VarChar, 20) { Value = txtRGM.Text }
                        );

                    if (dr.Read())
                    {
                        if (Convert.ToInt32(dr["contagem"]) > 0)
                        {
                            newRGM = false;
                        }
                        else
                        { }
                    }
                    dr.Close();
                }

                if (newRGM)
                {
                    if (cadastroCoordValidation())
                    {
                        using (ServicosDB db = new ServicosDB()) // INSERT DATABASE
                        {
                            string cmd = "insert into coordenador values(@rgm, @email, @senha, @nome, @dataNasc, @rg, @cpf)";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@rgm", SqlDbType.VarChar, 20) { Value = txtRGM.Text },
                                new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = txtEmail.Text },
                                new SqlParameter("@senha", SqlDbType.VarChar, 256) { Value = ServicosDB.stringToSHA256(pwdSenha.Text) },
                                new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                                new SqlParameter("@dataNasc", SqlDbType.Date) { Value = txtDataNasc.Text },
                                new SqlParameter("@rg", SqlDbType.VarChar, 9) { Value = txtRG.Text },
                                new SqlParameter("@cpf", SqlDbType.VarChar, 11) { Value = txtCPF.Text }
                                ) > 0)
                            {
                                alert("Cadastro efetuado com sucesso!");
                            }
                            else
                            {
                                alert("Falha ao cadastrar Coordenador!");
                            }
                        }
                        Response.Redirect("Home.aspx");
                    } else
                    {
                        alert("Um ou mais campos estão inválidos!");
                    }
                }
                else
                {
                    alert("Este RGM já está cadastrado!");
                }
            }
            catch (Exception exception)
            {
                alert("Falha ao Cadastrar Coordenador. Erro: "+exception.ToString());
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginCoordenador.aspx");
        }
    }
}