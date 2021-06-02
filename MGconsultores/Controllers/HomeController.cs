using MGconsultores.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace MGconsultores.Controllers
{
    public class HomeController : Controller
    {
        MGconsultoresEntities _db;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public string EnviarComentario(ComentarioModel model)
        {
            var rpta = "true";
            try
            {
                EnviarCorreo(model);
                //Comentarios entidad = new Comentarios();
                //entidad.DesComentario = model.Mensaje;
                //entidad.FechaCreacion = DateTime.Now;
                //entidad.Puntaje = model.Puntaje;
                //entidad.CodUsuario = string.Empty;

                //bool isAuth = User.Identity.IsAuthenticated;
                //if (isAuth)
                //{
                //    _db = new dbTuCalcuEntities();
                //    AspNetUsers user = _db.AspNetUsers.Where(m => m.Email == User.Identity.Name).ToList().FirstOrDefault();
                //    entidad.CodUsuario = user.Id;
                //}

                //ComentarioDA _da = new ComentarioDA();
                //_da.GrabarComentario(entidad);

                return rpta;

            }
            catch (Exception e)
            {
                rpta = CapturarError(e, "HomeController", "EnviarComentario");
                return "false";

            }

        }

        private void EnviarCorreo(ComentarioModel model)
        {

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            email.To.Add(new MailAddress(model.Correo));
            email.From = new MailAddress("contacto@mg-consultores.pe");
            email.Subject = "Notificación ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = model.Mensaje; // "Tu mensaje | tu firma";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //FileStream fs = new FileStream("E:\\TestFolder\\test.pdf", FileMode.Open, FileAccess.Read);
            //Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
            //email.Attachments.Add(a);

            smtp.Host = "mail.mg-consultores.pe";  
            smtp.Port = 25;
            smtp.Timeout = 50;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("contacto@mg-consultores.pe", "Zlatan2016");

            string lista = "contacto@mg-consultores.pe; miguel.gargurevich@gmail.com";
            string output = string.Empty;

            var mails = lista.Split(';');
            foreach (string dir in mails)
                email.To.Add(dir);

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (SmtpException exm)
            {
                CapturarError(exm, "Home", "EnviarComentario");
            }
            catch (Exception ex)
            {
                CapturarError(ex, "Home", "EnviarComentario");
            }

        }

        public string CapturarError(Exception error, string controlador = "", string accion = "")
        {
            var msg = error.Message;
            if (error.InnerException != null)
            {
                msg = msg + "/;/" + error.InnerException.Message;
                if (error.InnerException.InnerException != null)
                {
                    msg = msg + "/;/" + error.InnerException.InnerException.Message;
                    if (error.InnerException.InnerException.InnerException != null)
                        msg = msg + "/;/" + error.InnerException.InnerException.InnerException.Message;
                }
            }


            var comentario = $@"Se ejecutó la accion: [{controlador}/{accion}] - MensajeError: {msg}";
            var logErrorFinal = string.Format("{0} | {1}", comentario, error.StackTrace);
            //log.ErrorFormat("{0} | {1}", comentario, error.StackTrace);

            //PARA LOG ERROR
            var fileUnicoName = String.Concat("ERROR", ".txt");
            var fileUnicoPath = System.IO.Path.Combine(Server.MapPath("~/"), "Log", "Error", fileUnicoName);

            using (FileStream fs = new FileStream(fileUnicoPath, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(logErrorFinal);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            ViewBag.ErrorMessage = logErrorFinal;

            return string.Format(logErrorFinal);
        }

        public string CapturarError(SmtpException error, string controlador = "", string accion = "")
        {
            var msg = error.Message;
            if (error.InnerException != null)
            {
                msg = msg + "/;/" + error.InnerException.Message;
                if (error.InnerException.InnerException != null)
                {
                    msg = msg + "/;/" + error.InnerException.InnerException.Message;
                    if (error.InnerException.InnerException.InnerException != null)
                        msg = msg + "/;/" + error.InnerException.InnerException.InnerException.Message;
                }
            }


            var comentario = $@"Se ejecutó la accion: [{controlador}/{accion}] - MensajeError: {msg}";
            var logErrorFinal = string.Format("{0} | {1}", comentario, error.StackTrace);
            //log.ErrorFormat("{0} | {1}", comentario, error.StackTrace);

            //PARA LOG ERROR
            var fileUnicoName = String.Concat("ERROR", ".txt");
            var fileUnicoPath = System.IO.Path.Combine(Server.MapPath("~/"), "Log", "Error", fileUnicoName);

            using (FileStream fs = new FileStream(fileUnicoPath, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(logErrorFinal);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            ViewBag.ErrorMessage = logErrorFinal;

            return string.Format(logErrorFinal);
        }

    }
}