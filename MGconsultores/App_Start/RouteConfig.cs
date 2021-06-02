using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MGconsultores
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_AplicacionesMoviles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AplicacionesMoviles", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_AplicacionesWeb",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AplicacionesWeb", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_CalidadyGarantia",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CalidadyGarantia", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Default_ComoTrabajamos",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "ComoTrabajamos", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Default_Consultoria",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Consultoria", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default_Contacto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contacto", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_Cultura",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cultura", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_DesarrollodeSoftware",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DesarrollodeSoftware", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_DiseniodePaginasWeb",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DiseniodePaginasWeb", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Default_HostingyDominio",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "HostingyDominio", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Default_IntranetyExtranet",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "IntranetyExtranet", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Default_Nosotros",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Nosotros", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "Default_PaginaWebCatalogo",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "PaginaWebCatalogo", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
            name: "Default_PaginaWebCorporativa",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "PaginaWebCorporativa", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "Default_SoporteyMantenimiento",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "SoporteyMantenimiento", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "Default_TiendasVirtuales",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "TiendasVirtuales", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
        name: "Default_Examen",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Examen", action = "Index", id = UrlParameter.Optional }
    );


        }
    }
}
