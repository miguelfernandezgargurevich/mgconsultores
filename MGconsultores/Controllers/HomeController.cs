﻿using MGconsultores.Models;
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
using System.Configuration;

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