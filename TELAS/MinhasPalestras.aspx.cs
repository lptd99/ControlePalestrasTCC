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
    public partial class MinhasPalestras : System.Web.UI.Page
    {
        private void atualizarGrid()
        {
            using (ServicosDB db = new ServicosDB())
            {
                gvMinhasPalestras.DataSource = db.ExecQuery($"SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Sala', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante INNER JOIN [Inscricao] as I on P.id = I.idPalestra where I.rgmParticipante = '{Session["RGM_Usuario"]}'");
                gvMinhasPalestras.DataBind();
            }
        }
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizarGrid();
            if (Session["RGM_Usuario"] == null || Convert.ToBoolean(Session["Coordenador"]))
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }


        protected void gvMinhasPalestras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "avaliar")
            {
                int Linha = Convert.ToInt32(e.CommandArgument);
                int idPalestraAtual = Convert.ToInt32(gvMinhasPalestras.Rows[Linha].Cells[0].Text);
                string nomePalestraAtual = Convert.ToString(gvMinhasPalestras.Rows[Linha].Cells[1].Text);

                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select presente, nota from inscricao where rgmParticipante = @RGM_Usuario and idPalestra = @idPalestraAtual";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] },
                        new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual });

                    if (dr.Read())
                    {
                        if (Convert.ToBoolean(dr["presente"]))
                        {
                            if (Convert.ToInt32(dr["nota"]) == -1)
                            {
                                Session["Avaliando_Palestra_ID"] = idPalestraAtual;
                                Session["Avaliando_Palestra_Nome"] = nomePalestraAtual;
                                Response.Redirect("AvaliarPalestra.aspx");
                            }
                            else
                            {
                                alert("Você já avaliou esta Palestra!");
                            }
                        }
                        else
                        {
                            alert("Você não compareceu a esta Palestra!");
                        }
                    }
                    else
                    {
                        alert("Você não compareceu a esta Palestra!");
                    }
                    dr.Close();
                }
            }
            else if (e.CommandName == "imprimirCertificado")
            {
                int Linha = Convert.ToInt32(e.CommandArgument);
                int idPalestraAtual = Convert.ToInt32(gvMinhasPalestras.Rows[Linha].Cells[0].Text);
                
                Boolean presente = false;
                Boolean infoUsuario = false;
                Boolean infoPalestra = false;
                Boolean certificadoGerado = false;

                try
                {
                    using (ServicosDB db = new ServicosDB()) // READ DATABASE
                    {
                        string cmd = "select presente from inscricao where rgmParticipante = @RGM_Usuario and idPalestra = @idPalestraAtual";
                        SqlDataReader dr = db.ExecQuery(
                            cmd,
                            new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] },
                            new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual }
                            );

                        if (dr.Read())
                        {
                            if (Convert.ToBoolean(dr["presente"]))
                            {
                                presente = true;
                            }
                            else
                            {
                                alert("Você não compareceu a esta Palestra!");
                            }
                        }
                        dr.Close();
                    }
                }
                catch
                {
                    alert("Falha ao verificar Presença!");
                }

                string nome_usuario = "";
                string curso_usuario = "";
                string nome_palestrante = "";
                string nome_palestra = "";
                string data_inicio_palestra = "";
                string data_termino_palestra = "";

                if (presente)
                {
                    try
                    {
                        using (ServicosDB db = new ServicosDB()) // READ DATABASE
                        {
                            string cmd = "select nome, curso from participante where rgm = @RGM_Usuario";
                            SqlDataReader dr = db.ExecQuery(
                                cmd,
                                new SqlParameter("@RGM_Usuario", SqlDbType.VarChar, 11) { Value = Session["RGM_Usuario"] }
                                );

                            if (dr.Read())
                            {
                                nome_usuario = Convert.ToString(dr["nome"]);
                                curso_usuario = Convert.ToString(dr["curso"]);
                                infoUsuario = true;
                            }
                            else
                            {
                                alert("Falha ao coletar informações do Usuário!");
                            }
                            dr.Close();
                        }

                        using (ServicosDB db = new ServicosDB()) // READ DATABASE
                        {
                            string cmd = "select Pe.nome as 'Nome Palestrante', Pa.nome as 'Nome Palestra', Pa.dataHorarioInicio as 'DH Inicio', Pa.dataHorarioTermino as 'DH Termino' from Palestra as Pa INNER JOIN Palestrante as Pe on Pe.id = Pa.idPalestrante where Pa.id = @idPalestraAtual";
                            SqlDataReader dr = db.ExecQuery(
                                cmd,
                                new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual }
                                );

                            if (dr.Read())
                            {
                                nome_palestrante = Convert.ToString(dr["Nome Palestrante"]);
                                nome_palestra = Convert.ToString(dr["Nome Palestra"]);
                                data_inicio_palestra = Convert.ToString(dr["DH Inicio"]);
                                data_termino_palestra = Convert.ToString(dr["DH Termino"]);
                                infoPalestra = true;
                            }
                            else
                            {
                                alert("Falha ao coletar informações da Palestra!");
                            }
                            dr.Close();
                        }
                    }
                    catch
                    {
                        alert("Falha ao coletar informações do Usuário e/ou da Palestra!");
                    }
                }

                if(infoUsuario && infoPalestra)
                {
                    if (gerarCertificado(nome_usuario, curso_usuario, nome_palestrante, nome_palestra, data_inicio_palestra, data_termino_palestra))
                    {
                        Response.Redirect("Certificado.aspx");
                    }
                    else
                    {
                        alert("Falha ao gerar Certificado!");
                    }
                }
            }
        }

        private bool gerarCertificado(string nome_usuario, string curso_usuario, string nome_palestrante, string nome_palestra, string data_inicio_palestra, string data_termino_palestra)
        {
            try
            {
                // DATA INICIO STRING
                String[] dataHorarioInicioPair = data_inicio_palestra.Split(' ');
                String[] splitDateInicio = dataHorarioInicioPair[0].Split('/');
                String[] splitTimeInicio = dataHorarioInicioPair[1].Split(':');
                int anoI = Convert.ToInt32(splitDateInicio[2]);
                int mesI = Convert.ToInt32(splitDateInicio[1]);
                int diaI = Convert.ToInt32(splitDateInicio[0]);
                int horaI = Convert.ToInt32(splitTimeInicio[0]);
                int minutoI = Convert.ToInt32(splitTimeInicio[1]);
                int segundoI = Convert.ToInt32(splitTimeInicio[2]);

                DateTime dataHorarioInicio = new DateTime(anoI, mesI, diaI, horaI, minutoI, segundoI);

                // TIMESPAN STRING
                String[] dataHorarioTerminoPair = data_termino_palestra.Split(' ');
                String[] splitDateTermino = dataHorarioTerminoPair[0].Split('/');
                String[] splitTimeTermino = dataHorarioTerminoPair[1].Split(':');
                int anoT = Convert.ToInt32(splitDateTermino[2]);
                int mesT = Convert.ToInt32(splitDateTermino[1]);
                int diaT = Convert.ToInt32(splitDateTermino[0]);
                int horaT = Convert.ToInt32(splitTimeTermino[0]);
                int minutoT = Convert.ToInt32(splitTimeTermino[1]);
                int segundoT = Convert.ToInt32(splitTimeTermino[2]);

                DateTime dataHorarioTermino = new DateTime(anoT, mesT, diaT, horaT, minutoT, segundoT);

                TimeSpan timeSpan = dataHorarioTermino.Subtract(dataHorarioInicio);

                Session["CERTIFICADO_NOME_USUARIO"] = nome_usuario;
                Session["CERTIFICADO_CURSO_USUARIO"] = curso_usuario;
                Session["CERTIFICADO_NOME_PALESTRANTE"] = nome_palestrante;
                Session["CERTIFICADO_NOME_PALESTRA"] = nome_palestra;
                Session["CERTIFICADO_DATA_INICIO_PALESTRA"] = dataHorarioInicio.ToString();
                Session["CERTIFICADO_TIMESPAN_HORAS"] = timeSpan.Hours;
                Session["CERTIFICADO_TIMESPAN_MINUTOS"] = timeSpan.Minutes;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}