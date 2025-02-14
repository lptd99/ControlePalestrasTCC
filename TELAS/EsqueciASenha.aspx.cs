﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class EsqueciASenha : System.Web.UI.Page
    {
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int rgmLength = 0;
            if (Convert.ToBoolean(Session["EsqueciASenhaCoordenador"]))
            {
                rgmLength = 6;
            }
            else
            {
                rgmLength = 11;
            }

            if (txtRGM.Text != "" && txtRGM.Text.Length == rgmLength)
            {
                 //try {
                string nova_senha = "";
                string rgm = "";
                string email = "";


                if (Convert.ToBoolean(Session["EsqueciASenhaCoordenador"]))
                {
                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select rgm, email from coordenador where rgm = @RGM_Usuario";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 20) { Value = txtRGM.Text }
                            );

                        if (dr.Read())
                        {
                            try
                            {
                                rgm = Convert.ToString(dr["rgm"]);
                                email = Convert.ToString(dr["email"]);
                            }
                            catch
                            {
                                alert("RGM não cadastrado!");
                            }
                        }
                        else
                        {
                            alert("RGM não cadastrado!");
                        }
                        dr.Close();
                    }
                }
                else
                {
                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select rgm, email from participante where rgm = @RGM_Usuario";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = txtRGM.Text }
                            );

                        if (dr.Read())
                        {
                            try
                            {
                                rgm = Convert.ToString(dr["rgm"]);
                                email = Convert.ToString(dr["email"]);
                            }
                            catch
                            {
                                alert("RGM não cadastrado!");
                            }
                        }
                        else
                        {
                            alert("RGM não cadastrado!");
                        }
                        dr.Close();
                    }
                }
                

                if (rgm != "" && rgm.Length == rgmLength && email != "")
                {
                    string emailAlertSplit = email.Split('@')[0];
                    string emailAlert = "";
                    for (int i = 0; i < emailAlertSplit.Length; i++)
                    {
                        if (i > emailAlertSplit.Length / 10 && i < (emailAlertSplit.Length - (emailAlertSplit.Length / 10 + 1)))
                        {
                            emailAlert = emailAlert + '*';
                        }
                        else
                        {
                            emailAlert = emailAlert + emailAlertSplit[i];
                        }
                    }
                    emailAlert = emailAlert + "@" + email.Split('@')[1];

                    try
                    {
                        DateTime data = DateTime.Now;
                        int seed = Convert.ToInt32(data.Month.ToString() + data.Day.ToString() + data.Minute.ToString() + data.Second.ToString());
                        Random dice = new Random(seed);
                        nova_senha = Convert.ToString(dice.Next(111111111, 999999999));
                    }
                    catch
                    {
                        alert("Erro ao gerar nova senha. Tente novamente mais tarde.");
                    }

                    try
                    {
                        if (Convert.ToBoolean(Session["EsqueciASenhaCoordenador"]))
                        {
                            using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                            {
                                string cmd = "UPDATE coordenador SET senha = @senha where rgm = @rgm";
                                if (db.ExecUpdate(
                                    cmd,
                                    new SqlParameter("@senha", SqlDbType.VarChar, 256) { Value = ServicosDB.stringToSHA256(nova_senha) },
                                    new SqlParameter("@rgm", SqlDbType.VarChar, 20) { Value = rgm }
                                    ) > 0)
                                { }
                                else
                                {
                                    alert("Falha ao adicionar Palestrante!");
                                }
                            }
                        }
                        else
                        {
                            using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                            {
                                string cmd = "UPDATE participante SET senha = @senha where rgm = @rgm";
                                if (db.ExecUpdate(
                                    cmd,
                                    new SqlParameter("@senha", SqlDbType.VarChar, 256) { Value = ServicosDB.stringToSHA256(nova_senha) },
                                    new SqlParameter("@rgm", SqlDbType.VarChar, 11) { Value = rgm }
                                    ) > 0)
                                { }
                                else
                                {
                                    alert("Falha ao adicionar Palestrante!");
                                }
                            }
                        }

                        if (enviarEmailNovaSenha(email, rgm, nova_senha))
                        {
                            alert("Requisição efetuada! Dentro de alguns minutos, você deverá receber no email \"" + emailAlert + "\" a sua nova senha para o RGM \"" + rgm + "\"");
                        }
                    }
                    catch
                    {
                        alert("Requisição malsucedida! Verifique se o RGM digitado está correto e que este existe no sistema!");
                    }
                }
                else
                {
                    alert("Email ou RGM inválidos!");
                }
                //} catch {  }
            }
            else
            {
                alert("RGM inválido!");
            }
        }

        public bool enviarEmailNovaSenha(string emailDestinatário, string RGM, string novaSenha)
        {
            //try {
            // Estancia da Classe de Mensagem
            Boolean successful = true;

            MailMessage mailMessage = new MailMessage();

            try
            {

                // Remetente
                mailMessage.From = new MailAddress("umccontrolepalestras@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                mailMessage.CC.Add(emailDestinatário);
                mailMessage.Subject = "Recuperação de Senha para o Sistema de Palestras UMC";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<h1>Olá! Você requisitou uma redefinição de senha para o RGM " + RGM + "</h1><p>Sua nova senha é: " + novaSenha + "</p>";

            }
            catch
            {
                alert("Falha ao construir email!");
                successful = false;
            }

            //CONFIGURAÇÃO COM PORTA
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

            try
            {

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("umccontrolepalestras@gmail.com", "ControlePalestrasUMC888");
                smtpClient.EnableSsl = true;
            }
            catch
            {
                alert("Falha ao enviar email!");
                successful = false;
            }

            smtpClient.Send(mailMessage);

            return successful;
            //} catch (Exception ex) { alert("variaveis"); }
        }


        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["EsqueciASenhaCoordenador"] = false;
            Response.Redirect("Home.aspx");
        }
    }
}