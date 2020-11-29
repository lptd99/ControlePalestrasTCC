using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCADS.TELAS
{
    public partial class Certificado : System.Web.UI.Page
    {
        string textoCertificado = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (
                Session["RGM_Usuario"] == null ||
                Session["CERTIFICADO_NOME_USUARIO"] == null ||
                Session["CERTIFICADO_CURSO_USUARIO"] == null ||
                Session["CERTIFICADO_NOME_PALESTRANTE"] == null ||
                Session["CERTIFICADO_NOME_PALESTRA"] == null ||
                Session["CERTIFICADO_DATA_INICIO_PALESTRA"] == null ||
                Session["CERTIFICADO_TIMESPAN_HORAS"] == null ||
                Session["CERTIFICADO_TIMESPAN_MINUTOS"] == null
            )
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                textoCertificado = lblTexto.Text;                                                                                                       // textoCertificado = PLACEHOLDER TEXT
                textoCertificado = textoCertificado.Replace("[NOME_USUARIO]", Convert.ToString(Session["CERTIFICADO_NOME_USUARIO"]));
                textoCertificado = textoCertificado.Replace("[CURSO_USUARIO]", Convert.ToString(Session["CERTIFICADO_CURSO_USUARIO"]));
                textoCertificado = textoCertificado.Replace("[NOME_PALESTRANTE]", Convert.ToString(Session["CERTIFICADO_NOME_PALESTRANTE"]));
                textoCertificado = textoCertificado.Replace("[NOME_PALESTRA]", Convert.ToString(Session["CERTIFICADO_NOME_PALESTRA"]));
                textoCertificado = textoCertificado.Replace("[DATA_INICIO_PALESTRA]", Convert.ToString(Session["CERTIFICADO_DATA_INICIO_PALESTRA"]).Replace(" 00:00:00", ""));
                textoCertificado = textoCertificado.Replace("[TIMESPAN_HORAS]", Convert.ToString(Session["CERTIFICADO_TIMESPAN_HORAS"]));
                textoCertificado = textoCertificado.Replace("[TIMESPAN_MINUTOS]", Convert.ToString(Session["CERTIFICADO_TIMESPAN_MINUTOS"]));           // textoCertificado = DONE
                lblTexto.Text = textoCertificado;
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinhasPalestras.aspx");
        }
    }
}