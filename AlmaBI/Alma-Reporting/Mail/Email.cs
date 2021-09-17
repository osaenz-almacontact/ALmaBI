using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Alma_Reporting.Mail
{
    public class Email
    {
        static BaseEmail objMensaje = new BaseEmail();
        Boolean returnError = false;
        
        public static Boolean EnviarEmail(String prmDireccionCorreosDestino, String prmDirreccioCorreoOrigen, String prmNombreCorreo, String prmAsuntoCorreo, String prmContenidoCorreo) {
            MailMessage mensaje = new MailMessage();
            SmtpClient SMTP = new SmtpClient();
            Boolean correoError = false;
            try
            {
                ////foreach (MailAddress addr in v)
                ////{
                //    mensaje.To.Add(prmDireccionCorreosDestino);

                ////}

                //var credencial = new NetworkCredential
                //{
                //    UserName = "reportes@almacontactcol.co",
                //    Password = "Planeacion#2021",
                //};

                //mensaje.From = new MailAddress("reportes@almacontactcol.co", prmNombreCorreo);
                //mensaje.Subject = prmAsuntoCorreo;
                //mensaje.Body = prmContenidoCorreo;
                //mensaje.IsBodyHtml = true;

                //SMTP.Host = "smtp.office365.com";
                //SMTP.Port = 587;
                //SMTP.UseDefaultCredentials = false;
                //SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SMTP.EnableSsl = true;
                //SMTP.Credentials = credencial;
                //SMTP.Send(mensaje);

                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(prmDireccionCorreosDestino));
                msg.From = new MailAddress("autenticacion-almabi@outlook.com", prmNombreCorreo);
                msg.Subject = prmAsuntoCorreo;
                msg.Body = prmContenidoCorreo;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("autenticacion-almabi@outlook.com", "AlmaBi2021$");
                client.Port = 587; // You can use Port 25 if 587 is blocked
                client.Host = "smtp.office365.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                client.Send(msg);

            }
            catch (SmtpException smtp)
            {
                correoError = true;
                objMensaje.Message("No se puedo enviar el correo", smtp.Message, BaseEmail.TipoMensaje.Error, false);

            }
            catch (Exception e)
            {
                correoError = true;
                objMensaje.Message("¡Error!, ", e.Message, BaseEmail.TipoMensaje.Error, false);

            }
            finally {
                mensaje = null;
                SMTP = null;
            }
            return correoError;
        }
        //public MailAddressCollection buscarCorreosDetinatariosXConsultaIdUser(String[] prmNTs) {
        //    MailAddressCollection mailCorreo = new MailAddressCollection();
        //    String NTs = "";
        //    for (int i = 0; i < prmNTs.Length; i++) {
        //        if (prmNTs[i] != null) {
        //            if (i == prmNTs.Length)
        //            {
        //                NTs = NTs + "'"+ prmNTs[i]+"'";
        //            }
        //            else {
        //            }
        //        NTs=NTs+"'"+prmNTs[i]+"',";
        //        }
        //    }
        //    DataSet ds = new DataSet();
        //    String strSQL = "SELECT DISTINCT [E-mail] FROM WHERE NT IN (" + NTs + ")";
        //    ds = clsSQL.ejecutarProceConsulSQL(strSQL, ref returnError);
        //    if (ds.Tables[0].Rows.Count == 1) {
        //        foreach (DataRow dRow in ds.Tables[0].Rows) {
        //            mailCorreo.Add(dRow["[E-mail]"].ToString());
        //        }
        //    }
          
        //    return mailCorreo;
        //}
        public MailAddressCollection darDestinatarios(String[] prmDestinatarios) {
            MailAddressCollection mailAdress = new MailAddressCollection();
            try {
                for (int destinatario=0; destinatario < prmDestinatarios.Length; destinatario++) {
                    if (prmDestinatarios[destinatario] != null)
                    {
                        mailAdress.Add(prmDestinatarios[destinatario]);
                    }
                    
                }
            }
            catch (Exception e) {
                objMensaje.Message("¡Error!: ", e.Message, BaseEmail.TipoMensaje.Error, false);
                return null;
            }
            return mailAdress;
        }
    }
}