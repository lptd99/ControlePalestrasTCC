using System;
using System.Collections.Generic;
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
        #endregion

        #region Metodos auxiliares
        private bool cadastroPalestraValidation()
    {
            Boolean valid = true;
            #region prevenir conflito de horario e espaco
            try
            {
                Boolean conflito = false;
                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection,
                    $"select count(id) as conflitos from Palestra where idEspaco = {ddlEspaco.SelectedValue} and ('{txtDataHorarioInicio.Text}' = dataHorarioInicio or ('{txtDataHorarioInicio.Text}' > dataHorarioInicio and '{txtDataHorarioInicio.Text}' < dataHorarioTermino) or ('{txtDataHorarioTermino.Text}' > dataHorarioInicio and '{txtDataHorarioTermino.Text}' < dataHorarioTermino) or '{txtDataHorarioTermino.Text}' = dataHorarioTermino)");
                while (sqlDataReader.Read())
                {
                    try
                    {
                        conflito = Convert.ToInt32(sqlDataReader["conflitos"]) > 0;
                    }
                    catch (Exception ignored)
                    { }
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
                int anoI = Convert.ToInt32(splitDateInicio[0]);
                int mesI = Convert.ToInt32(splitDateInicio[2]);
                int diaI = Convert.ToInt32(splitDateInicio[1]);
                int horaI = Convert.ToInt32(splitTimeInicio[0]);
                int minutoI = Convert.ToInt32(splitTimeInicio[1]);
                int segundoI = Convert.ToInt32(splitTimeInicio[2]);
                DateTime dataHorarioInicio = new DateTime(Convert.ToInt32(splitDateInicio[0]), Convert.ToInt32(splitDateInicio[2]), Convert.ToInt32(splitDateInicio[1]), Convert.ToInt32(splitTimeInicio[0]), Convert.ToInt32(splitTimeInicio[1]), Convert.ToInt32(splitTimeInicio[2]));

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
                SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection,
                    $"select count(id) as conflitos from Palestra where idEspaco = {ddlEspaco.SelectedValue} and ('{txtDataHorarioInicio.Text}' = dataHorarioInicio or ('{txtDataHorarioInicio.Text}' > dataHorarioInicio and '{txtDataHorarioInicio.Text}' < dataHorarioTermino) or ('{txtDataHorarioTermino.Text}' > dataHorarioInicio and '{txtDataHorarioTermino.Text}' < dataHorarioTermino) or '{txtDataHorarioTermino.Text}' = dataHorarioTermino) and id != {txtID.Text}");
                while (sqlDataReader.Read())
                {
                    try
                    {
                        conflito = Convert.ToInt32(sqlDataReader["conflitos"]) > 0;
                    }
                    catch (Exception ignored)
                    { }
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

            return valid;
        }
        public int getNextID()
        {
            SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
            SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, "select max(id) as lastID from palestra");
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
            ddlPalestrante.SelectedIndex = 0;
            ddlCoordenador.SelectedIndex = 0;
            txtNome.Text = "";
            txtDataHorarioInicio.Text = "";
            txtDataHorarioTermino.Text = "";
            txtCurso.Text = "";
            ddlEspaco.SelectedIndex = 0;
            txtNota.Text = "0";
            txtInscritos.Text = "0";
        }
        private void atualizarGrid()
        {
            gvPalestras.DataSource = gvPalestrasDataSource;
            gvPalestras.DataBind();
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
                if (cadastroPalestraValidation())
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        $"insert into palestra values({ddlPalestrante.SelectedValue}, {ddlCoordenador.SelectedValue}, '{txtNome.Text}', '{txtDataHorarioInicio.Text}', '{txtDataHorarioTermino.Text}', '{txtCurso.Text}', {ddlEspaco.SelectedValue}, NULL, 0)",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                limparCampos();
                }
                sqlConnection.Close();
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Adicionar Palestra. Erro: " + exception.ToString());
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cadastroPalestraValidationUPDATE())
                {
                    if (Convert.ToInt32(txtID.Text) < getNextID())
                    {
                        SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                        SqlCommand sqlCommand = new SqlCommand(
                            $"UPDATE palestra SET idPalestrante = {ddlPalestrante.SelectedValue}, rgmCoordenador = {ddlCoordenador.SelectedValue}, nome = '{txtNome.Text}', dataHorarioInicio = '{txtDataHorarioInicio.Text}', dataHorarioTermino = '{txtDataHorarioTermino.Text}', curso = '{txtCurso.Text}', idEspaco = {ddlEspaco.SelectedValue} WHERE id = {txtID.Text}",
                            sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        limparCampos();
                    }
                    else
                    {
                        alert("Carregue uma Palestra primeiro!");
                    }
                }
                atualizarGrid();
            }
            catch (Exception exception)
            {
                alert("Falha ao Alterar Palestra. Erro: " + exception.ToString());
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
                        $"DELETE FROM palestra WHERE id = {txtID.Text}",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
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

                    SqlConnection sqlConnection = ServicosDB.createSQLServerConnection(@"DESKTOP_PCH001\TCCADS01", "TCCADS", "sa", "admin00");
                    SqlDataReader sqlDataReader = ServicosDB.createSQLCommandReader(sqlConnection, $"select * from palestra where id = {idPalestraAtual}");
                    while (sqlDataReader.Read())
                    {
                        txtID.Text = Convert.ToString(sqlDataReader["id"]);
                        ddlPalestrante.SelectedValue = Convert.ToString(sqlDataReader["idPalestrante"]);
                        ddlCoordenador.SelectedValue = Convert.ToString(sqlDataReader["rgmCoordenador"]);
                        txtNome.Text = Convert.ToString(sqlDataReader["nome"]);
                        txtDataHorarioInicio.Text = Convert.ToDateTime(sqlDataReader["dataHorarioInicio"]).ToString("yyyy-dd-MM HH:mm:ss");
                        txtDataHorarioTermino.Text = Convert.ToDateTime(sqlDataReader["dataHorarioTermino"]).ToString("yyyy-dd-MM HH:mm:ss");
                        txtCurso.Text = Convert.ToString(sqlDataReader["curso"]);
                        ddlEspaco.SelectedValue = Convert.ToString(sqlDataReader["idEspaco"]);
                        txtNota.Text = Convert.ToString(sqlDataReader["nota"]);
                        txtInscritos.Text = Convert.ToString(sqlDataReader["inscritos"]);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    alert("Falha ao Carregar Palestra. Erro: " + exception.ToString());
                }
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}