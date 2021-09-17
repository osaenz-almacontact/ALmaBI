using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Alma_Reporting.Mail
{
    public class BaseEmail
    {
        Boolean returnError = false;
        public enum TipoMensaje
        {
            Error = 0,
            Information = 1,
            Validacion = 2,
            Warning = 3
        }

        public void Message(String prmTitulo, String prmDescripcion, TipoMensaje prmtipo, Boolean prmVentana)
        {
            //if (!prmVentana)
            //{
            //    String lblTituloMensaje = prmTitulo;
            //    String lblDescripcionMensaje = prmDescripcion;
            //    String clrBackColor = String.Empty;
            //    String imgMensaje = String.Empty;
            //    switch (prmtipo)
            //    {
            //        case TipoMensaje.Error:
            //            CrearLogErr(prmTitulo, prmDescripcion);
            //            imgMensaje = "~/Resources/Mensaje/img_Error.png";
            //            clrBackColor = "#C10C0C";
            //            lblTituloMensaje = "Error";
            //            lblDescripcionMensaje = "Error of application, please inform the system administrator";
            //            break;
            //        case TipoMensaje.Information:
            //            imgMensaje = "~/Resources/Mensaje/img_Information.png";
            //            clrBackColor = "#272EAE";
            //            break;
            //        case TipoMensaje.Validacion:
            //            imgMensaje = "~/Resources/Mensaje/img_Validacion.png";
            //            clrBackColor = "#4F7946";
            //            break;
            //        case TipoMensaje.Warning:
            //            imgMensaje = "~/Resources/Mensaje/img_Warning.png";
            //            clrBackColor = "#ACB41C";
            //            break;
            //        default:
            //            imgMensaje = "~/Resources/Mensaje/img_Error.png";
            //            clrBackColor = "#C10C0C";
            //            break;



            //    }
            //    HttpContext.Current.Session["SURVEY_IMAGEN_ERROR"] = imgMensaje;
            //    HttpContext.Current.Session["SURVEY_DESCRIPCION_ERROR"] = lblDescripcionMensaje;
            //    HttpContext.Current.Session["SURVEY_TITULO_ERROR"] = lblTituloMensaje;
            //    HttpContext.Current.Session["SURVEY_COLOR_DESCRIPCION_ERROR"] = clrBackColor;

            //    //HttpContext.Current.Response.Redirect(p_UrlError);
            //}
            //else
            //{
            //    if (Page.Maser != null)
            //    {
            //        Label lblTituloMensaje;
            //        Label lblDescripcionMensaje;
            //        Panel plnMessage;
            //        Color clrBackColor;
            //        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();


            //        lblTituloMensaje = (Label)Master.FindControl("lbl_titulo_mensaje");
            //        lblDescripcionMensaje = (Label)Master.FindControl("lbl_descripcion_Mensaje");
            //        plnMessage = (Panel)Master.FindControl("pnl_Mensaje");
            //        img = (System.Web.UI.WebControls.Image)Master.FindControl("img_mensaje");
            //        lblTituloMensaje.Text = prmTitulo;
            //        lblDescripcionMensaje.Text = prmDescripcion;

            //        switch (prmtipo)
            //        {
            //            case TipoMensaje.Error:
            //                CrearLogErr(prmTitulo, prmDescripcion);
            //                clrBackColor = Color.FromName("#FFCECE");
            //                img.ImageUrl = "~/Resources/Mensaje/img_Error.png";
            //                lblTituloMensaje.Text = "Error";
            //                lblDescripcionMensaje.Text = "Error of application, please inform the system administrator";
            //                break;
            //            case TipoMensaje.Information:
            //                clrBackColor = Color.FromName("#272EAE");
            //                img.ImageUrl = "~/Resources/Mensaje/img_Information.png";
            //                break;
            //            case TipoMensaje.Validacion:
            //                clrBackColor = Color.FromName("#4F7946");
            //                img.ImageUrl = "~/Resources/Mensaje/img_Validacion.png";
            //                break;
            //            case TipoMensaje.Warning:
            //                clrBackColor = Color.FromName("#ACB41C");
            //                img.ImageUrl = "~/Resources/Mensaje/img_Warning.png";
            //                break;
            //            default:
            //                clrBackColor = Color.FromName("#0C2B03");
            //                img.ImageUrl = "~/Resources/Mensaje/img_Error.png";
            //                break;
            //        }
            //        plnMessage.ForeColor = clrBackColor;
            //        HttpContext.Current.Session["HP_AMBAR_ERR_DESCRIPTION"] = lblDescripcionMensaje.Text;
            //        HttpContext.Current.Session["HP_AMBAR_ERR_TITLE"] = lblTituloMensaje.Text;
            //        HttpContext.Current.Session["HP_AMBAR_ERR_COLOR"] = clrBackColor.Name.ToString();
            //        HttpContext.Current.Session["HP_AMBAR_PANEL_MENSAJE"] = "1";

            //        plnMessage.Visible = Convert.ToBoolean(Convert.ToInt32(HttpContext.Current.Session["HP_AMBAR_PANEL_MENSAJE"].ToString()));
            //        HttpContext.Current.Session["MENSAJE"] = plnMessage;
            //    }

            //}
        }

        public void CrearLogErr(String prmTitlo, String prmDescripcion)
        {
            StreamWriter A_Fichero = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + @"\log\Application.log", true);
            A_Fichero.WriteLine("********************");
            A_Fichero.WriteLine();
            A_Fichero.WriteLine(prmTitlo);
            A_Fichero.WriteLine("Descripción: " + prmTitlo);
            A_Fichero.WriteLine("Usuario: " + HttpContext.Current.Request.ServerVariables["LOGON_USER"].ToString());
            A_Fichero.WriteLine();
            A_Fichero.WriteLine("********************");
            A_Fichero.Flush();
            A_Fichero.Close();
        }

        public static String crearRetornarCuerpoCorreo(String prmTituloMensaje, String prmDescripcion, String prmFirma, String prmArea)
        {

            String titulo = "<table align='center' style='margin: 10px 50px 10px 50px;width:600px;font-family:century gothic;' cellpadding=0 cellspacing=0>";
            titulo += "<tr><td><p style='font-size:30px;color:#12679B;text-align:center;margin-left:20px;margin-top:25px;font-family:century gothic;'>ALMA-BI</p></strong></td></tr>";
            titulo += "<tr><td><hr style='color:#12679B' size='5' /></td></tr>";
            titulo += "<tr><td style='font-size:18px;color:White;background-color:#12679B;text-align:center'><strong>" + prmTituloMensaje + "</strong></td></tr>";

            String descripcion = "<tr><td>";
            descripcion += prmDescripcion;
            descripcion += "</td></tr>";
            String firma = "<tr><td><hr style='color:#A6A6A7' size='5' /> <br/></td></tr><tr><td><p style='font-size:16px;color:#585964;margin-bottom:6px'><strong>Cordialmente:</strong></p><p style='margin:0px;color:#A6A6A7;font-size:14px;'><strong>" + prmFirma + "</strong></p></td></tr></table>";
            String html = "<html><body><div style='width:100%;margin:0px'>" + titulo + descripcion + firma + "</div></body></html>";

            return html;
        }


    }
}