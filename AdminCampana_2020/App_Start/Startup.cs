﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AdminCampana_2020.App_Start.Startup))]

namespace AdminCampana_2020.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
                {
                    //especificamos el tipo de autenticacion que vamos a necesitar
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    //login path indica que debe cambiar al status 401 unauthorized por el status 302 el cual nos redicrecciona a una ruta especifica
                    LoginPath = new PathString("/account/login")

                }
                );
            ///utilizamos una cookie para autenticacion externa de la siguiente manera 
            ///utilizaremos proveedores de servicios de autenticacion como facebook y google
            app.UseExternalSignInCookie(
                DefaultAuthenticationTypes.ExternalCookie ///utilizamos una cookie externa    
            );
            ///utilizaremos una cookie externa para poder logearnos en nuestra aplicacion
            app.UseFacebookAuthentication(appId: "473117726940272", appSecret: "73287401352f91d8a34b74ad35c68725");
            ///utilizaremos una cookie externa de microsoft account para logearnos
            app.UseMicrosoftAccountAuthentication(clientId: "some one", clientSecret: "some one");
            ///utilizamos una ccokie externa para logearnos con google
            app.UseGoogleAuthentication(clientId: "some one", clientSecret: "some one");
            //twitter autgentication cookie
        }
    }
}
