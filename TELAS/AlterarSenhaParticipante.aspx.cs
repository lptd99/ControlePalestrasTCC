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
    public partial class AlterarSenhaParticipante : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        private bool alterarSenhaValidation()
        {
            Boolean novaSenhaValida = true;
            Boolean senhaAtualCorreta = false;

            // Senha validation
            if (Convert.ToBoolean(Session["AlterarSenhaCoordenador"]))
            {
                try
                {
                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select senha from coordenador where rgm = @RGM_Usuario";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 20) { Value = txtRGM.Text }
                            );

                        if (dr.Read())
                        {
                            if (Convert.ToString(dr["senha"]) == ServicosDB.stringToSHA256(txtSenhaAtual.Text))
                            {
                                senhaAtualCorreta = true;
                            }
                            else
                            {
                                senhaAtualCorreta = false;
                            }
                        }
                        dr.Close();
                    }
                }
                catch
                {
                    alert("Falha ao confirmar Senha Atual!");
                }
            }
            else
            {
                try
                {
                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select senha from participante where rgm = @RGM_Usuario";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = txtRGM.Text }
                            );

                        if (dr.Read())
                        {
                            if (Convert.ToString(dr["senha"]) == ServicosDB.stringToSHA256(txtSenhaAtual.Text))
                            {
                                senhaAtualCorreta = true;
                            }
                            else
                            {
                                senhaAtualCorreta = false;
                            }
                        }
                        dr.Close();
                    }
                }
                catch
                {
                    alert("Falha ao confirmar Senha Atual!");
                }
            }

            if (!senhaAtualCorreta)
            {
                alert("Senha Atual incorreta!");
            }

            if (txtNovaSenha.Text != txtConfirmarNovaSenha.Text || txtNovaSenha.Text.Length > 30 || txtNovaSenha.Text == "" || txtNovaSenha.Text == txtSenhaAtual.Text)
            {
                novaSenhaValida = false;
                alert("Nova Senha inválida! Ambos os campos de Nova Senha devem ser iguais e ter um máximo de 30 caracteres, além de não poderem ser iguais à senha atual nem vazios.");
            }

            return novaSenhaValida && senhaAtualCorreta;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtRGM.Text = Convert.ToString(Session["RGM_Usuario"]);
                if(txtRGM.Text == "")
                {
                    Response.Redirect("HomeParticipante.aspx");
                }
            }
            catch
            {
                Response.Redirect("HomeParticipante.aspx");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["AlterarSenhaCoordenador"] = false;
            Response.Redirect("HomeParticipante.aspx");
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (alterarSenhaValidation())
            {
                if (Convert.ToBoolean(Session["AlterarSenhaCoordenador"]))
                {
                    try
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "UPDATE coordenador SET senha = @novaSenha where rgm = @rgm";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@novaSenha", SqlDbType.VarChar, 256) { Value = ServicosDB.stringToSHA256(txtNovaSenha.Text) },
                                new SqlParameter("@rgm", SqlDbType.VarChar, 20) { Value = txtRGM.Text }
                                ) > 0)
                            {
                                alert("Senha alterada com sucesso!");
                            }
                            else { alert("Falha ao efetuar alteração!"); }
                        }
                    }
                    catch
                    {
                        alert("Falha ao efetuar alteração!");
                    }
                }
                else
                {
                    try
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "UPDATE participante SET senha = @novaSenha where rgm = @rgm";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@novaSenha", SqlDbType.VarChar, 256) { Value = ServicosDB.stringToSHA256(txtNovaSenha.Text) },
                                new SqlParameter("@rgm", SqlDbType.VarChar, 11) { Value = txtRGM.Text }
                                ) > 0)
                            {
                                alert("Senha alterada com sucesso!");
                            }
                            else { alert("Falha ao efetuar alteração!"); }
                        }
                    }
                    catch
                    {
                        alert("Falha ao efetuar alteração!");
                    }
                }
            }
        }
    }
}