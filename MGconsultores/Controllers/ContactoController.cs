using MGconsultores.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MGconsultores.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            string mailFrom = ConfigurationManager.AppSettings["mailFrom"];
            string mailHost = ConfigurationManager.AppSettings["mailHost"];
            string mailPass = ConfigurationManager.AppSettings["mailPass"];
            string mailTo = ConfigurationManager.AppSettings["mailTo"];

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            //email.To.Add(new MailAddress(model.Correo));
            email.From = new MailAddress(mailFrom);
            email.Subject = "MG Consultores - Notificación (" + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + ")";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = String.Concat(model.Mensaje, " | ", model.Correo); // "Tu mensaje | tu firma";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //FileStream fs = new FileStream("E:\\TestFolder\\test.pdf", FileMode.Open, FileAccess.Read);
            //Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
            //email.Attachments.Add(a);

            smtp.Host = mailHost;
            smtp.Port = 25;
            smtp.Timeout = 50;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mailFrom, mailPass);

            string lista = mailTo;
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
                string error = CapturarError(exm, "Home", "EnviarComentario");
                output = String.Concat("No se puede enviar correos por el momento: ", error);
            }
            catch (Exception ex)
            {
                string error = CapturarError(ex, "Home", "EnviarComentario");
                output = String.Concat("No se puede enviar correos por el momento: ", error);
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
