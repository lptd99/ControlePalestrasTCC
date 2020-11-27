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
    public partial class GerenciarPalestras : System.Web.UI.Page
    {

        #region Variaveis
        int nextID = 0;
        int anoI;
        int mesI;
        int diaI;
        int horaI;
        int minutoI;
        int segundoI;
        String stringDataHorarioInicio = "";

        int anoT;
        int mesT;
        int diaT;
        int horaT;
        int minutoT;
        int segundoT;
        String stringDataHorarioTermino = "";
        #endregion

        #region Metodos auxiliares
        private bool cadastroPalestraValidation()
    {
            Boolean valid = true;
            #region prevenir conflito de horario e espaco
            try
            {
                Boolean conflito = false;
                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select count(id) as conflitos from Palestra where idEspaco = @idEspaco and (@dataHorarioInicio = dataHorarioInicio or (@dataHorarioInicio > dataHorarioInicio and @dataHorarioInicio < dataHorarioTermino) or (@dataHorarioTermino > dataHorarioInicio and @dataHorarioTermino < dataHorarioTermino) or @dataHorarioTermino = dataHorarioTermino)";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@idEspaco", SqlDbType.Int) { Value = ddlEspaco.SelectedValue },
                        new SqlParameter("@dataHorarioInicio", SqlDbType.VarChar, 30) { Value = txtDataHorarioInicio.Text },
                        new SqlParameter("@dataHorarioTermino", SqlDbType.VarChar, 30) { Value = txtDataHorarioTermino.Text }
                        );

                    if (dr.Read())
                    {
                        conflito = Convert.ToInt32(dr["conflitos"]) > 0;
                    }
                    dr.Close();
                }

                if (conflito)
                {
                    alert("Este horário conflita com uma Palestra já existente no mesmo local!");
                    valid = false;
                }
            }
            catch (Exception exception)
            {
                alert("Falha ao Verificar Conflitos de Horário. Erro: " + exception.ToString());
            }
            #endregion

            #region validar data e horario
            try
            {
                String[] dataHorarioInicioPair = txtDataHorarioInicio.Text.Split(' ');
                String[] splitDateInicio = dataHorarioInicioPair[0].Split('-');
                String[] splitTimeInicio = dataHorarioInicioPair[1].Split(':');
                anoI = Convert.ToInt32(splitDateInicio[0]);
                mesI = Convert.ToInt32(splitDateInicio[2]);
                diaI = Convert.ToInt32(splitDateInicio[1]);
                horaI = Convert.ToInt32(splitTimeInicio[0]);
                minutoI = Convert.ToInt32(splitTimeInicio[1]);
                segundoI = Convert.ToInt32(splitTimeInicio[2]);
                DateTime dataHorarioInicio = new DateTime(anoI, mesI, diaI, horaI, minutoI, segundoI);
                stringDataHorarioInicio = splitDateInicio[0] + "-" + splitDateInicio[2] + "-" + splitDateInicio[1] + " " + splitTimeInicio[0] + ":" + splitTimeInicio[1] + ":" + splitTimeInicio[2];

                String[] dataHorarioTerminoPair = txtDataHorarioTermino.Text.Split(' ');
                String[] splitDateTermino = dataHorarioTerminoPair[0].Split('-');
                String[] splitTimeTermino = dataHorarioTerminoPair[1].Split(':');
                anoT = Convert.ToInt32(splitDateTermino[0]);
                mesT = Convert.ToInt32(splitDateTermino[2]);
                diaT = Convert.ToInt32(splitDateTermino[1]);
                horaT = Convert.ToInt32(splitTimeTermino[0]);
                minutoT = Convert.ToInt32(splitTimeTermino[1]);
                segundoT = Convert.ToInt32(splitTimeTermino[2]);
                DateTime dataHorarioTermino = new DateTime(anoT, mesT, diaT, horaT, minutoT, segundoT);
                stringDataHorarioTermino = splitDateTermino[0] + "-" + splitDateTermino[2] + "-" + splitDateTermino[1] + " " + splitTimeTermino[0] + ":" + splitTimeTermino[1] + ":" + splitTimeTermino[2];


                if (dataHorarioInicio == dataHorarioTermino || dataHorarioInicio > dataHorarioTermino )
                {
                    alert("Data e Horário inválidos!");
                    valid = false;
                }
            }
            catch (Exception ignored)
            {
                alert("Os campos Data e Horário devem ser preenchidos conforme o modelo!");
                valid = false;
            }
            #endregion

            #region validar curso e nome
            if (txtNome.Text == "" || txtNome.Text.Length > 100 ||
                    txtCurso.Text == "" || txtCurso.Text.Length > 100)
            {
                alert("Os campos Nome e Curso não podem ser vazios, nem ultrapassar 100 caracteres cada.");
                valid = false;
            }
            #endregion

            if (ddlEspaco.Items.Count == 0)
            {
                alert("Você deve ter um Espaco cadastrado e selecionado para criar uma Palestra!");
                valid = false;
            }

            if (ddlPalestrante.Items.Count == 0)
            {
                alert("Você deve ter um Palestrante cadastrado e selecionado para criar uma Palestra!");
                valid = false;
            }

            return valid;
        }
        private bool cadastroPalestraValidationUPDATE()
        {
            Boolean valid = true;
            Boolean conflito = false;

            #region validar data e horario
            try
            {
                String[] dataHorarioInicioPair = txtDataHorarioInicio.Text.Split(' ');
                String[] splitDateInicio = dataHorarioInicioPair[0].Split('-');
                String[] splitTimeInicio = dataHorarioInicioPair[1].Split(':');
                int anoI = Convert.ToInt32(splitDateInicio[0]);
                int mesI = Convert.ToInt32(splitDateInicio[2]);
                int diaI = Convert.ToInt32(splitDateInicio[1]);
                int horaI = Convert.ToInt32(splitTimeInicio[0]);
                int minutoI = Convert.ToInt32(splitTimeInicio[1]);
                int segundoI = Convert.ToInt32(splitTimeInicio[2]);
                DateTime dataHorarioInicio = new DateTime(Convert.ToInt32(splitDateInicio[0]), Convert.ToInt32(splitDateInicio[2]), Convert.ToInt32(splitDateInicio[1]), Convert.ToInt32(splitTimeInicio[0]), Convert.ToInt32(splitTimeInicio[1]), Convert.ToInt32(splitTimeInicio[2]));
                stringDataHorarioInicio = splitDateInicio[0] + "-" + splitDateInicio[2] + "-" + splitDateInicio[1] + " " + splitTimeInicio[0] + ":" + splitTimeInicio[1] + ":" + splitTimeInicio[2];

                String[] dataHorarioTerminoPair = txtDataHorarioTermino.Text.Split(' ');
                String[] splitDateTermino = dataHorarioTerminoPair[0].Split('-');
                String[] splitTimeTermino = dataHorarioTerminoPair[1].Split(':');
                int anoP = Convert.ToInt32(splitDateTermino[0]);
                int mesP = Convert.ToInt32(splitDateTermino[2]);
                int diaP = Convert.ToInt32(splitDateTermino[1]);
                int horaP = Convert.ToInt32(splitTimeTermino[0]);
                int minutoP = Convert.ToInt32(splitTimeTermino[1]);
                int segundoP = Convert.ToInt32(splitTimeTermino[2]);
                DateTime dataHorarioTermino = new DateTime(Convert.ToInt32(splitDateTermino[0]), Convert.ToInt32(splitDateTermino[2]), Convert.ToInt32(splitDateTermino[1]), Convert.ToInt32(splitTimeTermino[0]), Convert.ToInt32(splitTimeTermino[1]), Convert.ToInt32(splitTimeTermino[2]));
                stringDataHorarioTermino = splitDateTermino[0] + "-" + splitDateTermino[2] + "-" + splitDateTermino[1] + " " + splitTimeTermino[0] + ":" + splitTimeTermino[1] + ":" + splitTimeTermino[2];

                if (dataHorarioInicio == dataHorarioTermino || dataHorarioInicio > dataHorarioTermino)
                {
                    alert("Data e Horário inválidos!");
                    valid = false;
                }
            }
            catch (Exception ignored)
            {
                alert("Os campos Data e Horário devem ser preenchidos conforme o modelo!");
                valid = false;
            }
            #endregion

            #region prevenir conflito de horario e espaco
            try
            {
                using (ServicosDB db = new ServicosDB()) // READ DATABASE
                {
                    string cmd = "select count(id) as conflitos from Palestra where idEspaco = @idEspaco and (@dataHorarioInicio = dataHorarioInicio or (@dataHorarioInicio > dataHorarioInicio and @dataHorarioInicio < dataHorarioTermino) or (@dataHorarioTermino > dataHorarioInicio and @dataHorarioTermino < dataHorarioTermino) or @dataHorarioTermino = dataHorarioTermino) and id != @idPalestraAtual";
                    SqlDataReader dr = db.ExecQuery(
                        cmd,
                        new SqlParameter("@idEspaco", SqlDbType.Int) { Value = ddlEspaco.SelectedValue },
                        new SqlParameter("@dataHorarioInicio", SqlDbType.VarChar, 30) { Value = txtDataHorarioInicio.Text },
                        new SqlParameter("@dataHorarioTermino", SqlDbType.VarChar, 30) { Value = txtDataHorarioTermino.Text },
                        new SqlParameter("@idPalestraAtual", SqlDbType.VarChar, 30) { Value = txtID.Text }
                        );

                    if (dr.Read())
                    {
                        conflito = Convert.ToInt32(dr["conflitos"]) > 0;
                    }
                    dr.Close();
                }

                if (conflito)
                {
                    alert("Este horário conflita com uma Palestra já existente no mesmo local!");
                    valid = false;
                }
            }
            catch (Exception exception)
            {
                alert("Falha ao verificar Conflitos de Horário. Erro: " + exception.ToString());
            }
            #endregion

            #region validar curso e nome
            if (txtNome.Text == "" || txtNome.Text.Length > 100 ||
                    txtCurso.Text == "" || txtCurso.Text.Length > 100)
            {
                alert("Os campos Nome e Curso não podem ser vazios, nem ultrapassar 100 caracteres cada.");
                valid = false;
            }
            #endregion

            if (ddlEspaco.Items.Count == 0)
            {
                alert("Você deve ter um Espaco cadastrado e selecionado para criar uma Palestra!");
                valid = false;
            }

            if (ddlPalestrante.Items.Count == 0)
            {
                alert("Você deve ter um Palestrante cadastrado e selecionado para criar uma Palestra!");
                valid = false;
            }

            return valid;
        }
        public int getNextID()
        {
            using (ServicosDB db = new ServicosDB()) // READ DATABASE
            {
                string cmd = "select max(id) as lastID from palestra";
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
            try {
                ddlPalestrante.SelectedIndex = 0;
                ddlCoordenador.SelectedIndex = 0;
                ddlEspaco.SelectedIndex = 0;
            } catch { }
            txtNome.Text = "";
            txtDataHorarioInicio.Text = "";
            txtDataHorarioTermino.Text = "";
            txtCurso.Text = "";
            txtNota.Text = "0";
            txtInscritos.Text = "0";
        }
        private void atualizarGrid()
        {
            using (ServicosDB db = new ServicosDB())
            {
                gvPalestras.DataSource = db.ExecQuery($"SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Local', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante");
                gvPalestras.DataBind();
            }
        }
        public void alert(string Msg)
        {
            Response.Write($"<script>alert('{Msg}');</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                atualizarDDLs();
            }

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

        private void atualizarDDLs()
        {
            using (ServicosDB db = new ServicosDB())
            {
                ddlCoordenador.DataSource = db.ExecQuery($"SELECT [rgm], [nome] FROM [Coordenador]");
                ddlCoordenador.DataBind();
            }

            using (ServicosDB db = new ServicosDB())
            {
                ddlPalestrante.DataSource = db.ExecQuery($"SELECT [id], [nome] FROM [Palestrante]");
                ddlPalestrante.DataBind();
            }

            using (ServicosDB db = new ServicosDB())
            {
                ddlEspaco.DataSource = db.ExecQuery($"SELECT [id], [nome], [capacidade] FROM [Espaco]");
                ddlEspaco.DataBind();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cadastroPalestraValidation())
            {
                using (ServicosDB db = new ServicosDB()) // INSERT DATABASE
                {
                    string cmd = "insert into palestra values(@idPalestrante, @rgmCoordenador, @nome, @dataHorarioInicio, @dataHorarioTermino, @curso, @idEspaco, NULL, 0)";
                    if (db.ExecUpdate(
                        cmd,
                        new SqlParameter("@idPalestrante", SqlDbType.Int) { Value = ddlPalestrante.SelectedValue },
                        new SqlParameter("@rgmCoordenador", SqlDbType.VarChar, 20) { Value = ddlCoordenador.SelectedValue },
                        new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                        new SqlParameter("@dataHorarioInicio", SqlDbType.DateTime) { Value = stringDataHorarioInicio },
                        new SqlParameter("@dataHorarioTermino", SqlDbType.DateTime) { Value = stringDataHorarioTermino },
                        new SqlParameter("@curso", SqlDbType.VarChar, 100) { Value = txtCurso.Text },
                        new SqlParameter("@idEspaco", SqlDbType.Int) { Value = ddlEspaco.SelectedValue }
                        ) > 0)
                    {
                        int id = Convert.ToInt32(db.QueryValue("select @@identity"));
                        txtID.Text = $"{id}";
                        limparCampos();
                        atualizarDDLs();
                    }
                    else
                    {
                        alert("Falha ao adicionar Palestra!");
                    }
                    atualizarGrid();
                }
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            //try {
                if (cadastroPalestraValidationUPDATE())
                {
                    if (Convert.ToInt32(txtID.Text) < getNextID())
                    {
                        using (ServicosDB db = new ServicosDB()) // UPDATE DATABASE
                        {
                            string cmd = "update palestra set idPalestrante = @idPalestrante, rgmCoordenador = @rgmCoordenador, nome = @nome, dataHorarioInicio = @dataHorarioInicio, dataHorarioTermino = @dataHorarioTermino, curso = @curso, idEspaco = @idEspaco where id = @idPalestraAtual";
                            if (db.ExecUpdate(
                                cmd,
                                new SqlParameter("@idPalestrante", SqlDbType.Int) { Value = ddlPalestrante.SelectedValue },
                                new SqlParameter("@rgmCoordenador", SqlDbType.VarChar, 20) { Value = ddlCoordenador.SelectedValue },
                                new SqlParameter("@nome", SqlDbType.VarChar, 100) { Value = txtNome.Text },
                                new SqlParameter("@dataHorarioInicio", SqlDbType.DateTime) { Value = stringDataHorarioInicio },
                                new SqlParameter("@dataHorarioTermino", SqlDbType.DateTime) { Value = stringDataHorarioTermino },
                                new SqlParameter("@curso", SqlDbType.VarChar, 100) { Value = txtCurso.Text },
                                new SqlParameter("@idEspaco", SqlDbType.Int) { Value = ddlEspaco.SelectedValue },
                                new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = txtID.Text }
                                ) > 0)
                            {
                                limparCampos();
                                atualizarDDLs();
                        }
                            else
                            {
                                alert("Falha ao alterar Palestra!");
                            }
                        }
                    }
                    else
                    {
                        alert("Carregue uma Palestra primeiro!");
                    }
                }
                else
                {
                    alert("Um ou mais campos inválidos!");
                }
                atualizarGrid();
            //} catch (Exception exception) { alert("Falha ao Alterar Palestra. Erro: " + exception.ToString()); }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtID.Text) < getNextID())
                {
                    using (ServicosDB db = new ServicosDB()) // DELETE DATABASE
                    {
                        string cmd = "delete from palestra where id = @idPalestraAtual";
                        if (db.ExecUpdate(
                            cmd,
                            new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = txtID.Text }
                            ) > 0)
                        {
                            limparCampos();
                            atualizarDDLs();
                        }
                        else
                        {
                            alert("Falha ao excluir Palestra!");
                        }
                        atualizarGrid();
                    }
                }
                else
                {
                    alert("Carregue uma Palestra primeiro!");
                }
                limparCampos();
                atualizarGrid();
            }
            catch
            {
                alert("Esta Palestra já possui participantes inscritos!");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeCoordenador.aspx");
        }

        protected void gvPalestras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "carregar")
            {
                try
                {
                    int Linha = Convert.ToInt32(e.CommandArgument);
                    int idPalestraAtual = Convert.ToInt32(gvPalestras.Rows[Linha].Cells[0].Text);

                    using (ServicosDB db = new ServicosDB())
                    {
                        SqlDataReader dr = db.ExecQuery(
                            "select * from palestra where id = @idPalestraAtual",
                            new SqlParameter("@idPalestraAtual", SqlDbType.Int) { Value = idPalestraAtual });

                        if (dr.Read())
                        {
                            txtID.Text = $"{dr["id"]}";
                            ddlPalestrante.SelectedValue = $"{dr["idPalestrante"]}";
                            ddlCoordenador.SelectedValue = $"{dr["rgmCoordenador"]}";
                            txtNome.Text = $"{dr["nome"]}";
                            txtDataHorarioInicio.Text = $"{Convert.ToDateTime(dr["dataHorarioInicio"]).ToString("yyyy-dd-MM HH:mm:ss")}";
                            txtDataHorarioTermino.Text = $"{Convert.ToDateTime(dr["dataHorarioTermino"]).ToString("yyyy-dd-MM HH:mm:ss")}";
                            txtCurso.Text = $"{dr["curso"]}";
                            ddlEspaco.SelectedValue = $"{dr["idEspaco"]}";
                            txtNota.Text = $"{dr["nota"]}";
                            txtInscritos.Text = $"{dr["inscritos"]}";
                            atualizarDDLs();
                        }
                        dr.Close();
                    }
                }
                catch (Exception exception)
                {
                    alert("Falha ao Carregar Palestra. Erro: " + exception.ToString());
                }
            }

            if (e.CommandName == "enviar_presenca")
            {
                try
                {
                    int Linha = Convert.ToInt32(e.CommandArgument);
                    DateTime dataHorarioTermino = Convert.ToDateTime(gvPalestras.Rows[Linha].Cells[3].Text);
                    if (dataHorarioTermino < DateTime.Now)
                    {
                        Session["Enviar_Presenca_Palestra_ID"] = Convert.ToString(gvPalestras.Rows[Linha].Cells[0].Text);
                        Session["Enviar_Presenca_Palestra_Nome"] = Convert.ToString(gvPalestras.Rows[Linha].Cells[1].Text);
                        Response.Redirect("EnviarPresenca.aspx");
                    }
                    else
                    {
                        alert("Esta Palestra ainda não acabou!");
                    }
                }
                catch
                {
                    alert("Falha ao entrar na tela de envio de presença.");
                }
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}