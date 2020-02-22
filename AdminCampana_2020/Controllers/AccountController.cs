using AdminCampana_2020.Encript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminCampana_2020.ViewModels;
using AdminCampana_2020.Domain;
using AdminCampana_2020.Business.Interface;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using AdminCampana_2020.Helpers;
using System.Threading.Tasks;

namespace AdminCampana_2020.Controllers
{
    public class AccountController : Controller
    {
        IUsuarioBusiness usuarioBusiness;
        public AccountController(IUsuarioBusiness _usuarioBusiness)
        {
            usuarioBusiness = _usuarioBusiness;
        }


        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM loginView, string returnUrl)
        {
            ActionResult result; //esto se debe inicializar
            string clave = Funciones.Encrypt(loginView.Password); //encryptamos el password
            UsuarioDomainModel usuarioDM = usuarioBusiness.ValidarLogin(loginView.Email, clave);
            if (usuarioDM != null)
            {
                result = SigInUser(usuarioDM, loginView.RememberMe, returnUrl);
            }
            else
            {
                return View(loginView);
            }

            return result;

        }


        private ActionResult SigInUser(UsuarioDomainModel userDM, bool rememberMe, string returnUrl)
        {
            ActionResult Result;
            //un claims puede almacenar cualquier tipo de informacion del usuario, nombre, mail, password, lo que sea
            List<Claim> Claims = new List<Claim>(); //listado de claims
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, userDM.Id.ToString())); //primer claims
            Claims.Add(new Claim(ClaimTypes.Email, userDM.Email));
            Claims.Add(new Claim(ClaimTypes.Name, userDM.Nombres));
            ///podemos crear un tipo de claims personalizado
            Claims.Add(new Claim("FullName", $"{userDM.Nombres} {userDM.Apellidos}"));
            ///estos claims se almacenan en la cookie para identificar al usuario y sus atributos o permisos

            //ahora establñecemos los claims con los roles del usuario
            if (userDM.UsuarioRolesDM != null && userDM.UsuarioRolesDM.Any())
            {
                Claims.AddRange(userDM.UsuarioRolesDM.Select(p => new Claim(ClaimTypes.Role, p.Rol.Nombre)));
            }
            var Identity = new ClaimsIdentity(Claims, DefaultAuthenticationTypes.ApplicationCookie); //entonces ahora creamos una identidad basada en claims con sus roles permisos y nombre del usuario
            ///cuando el usuario se logea se crea una cookie de autenticacion 
            ///
            //este AutenticationManager se encarga de administrarla cookie y da el seguimiento a todo el sitio con todo y los permisos del usuario
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = rememberMe }, Identity); //el rememberMe es para recordarlo true/false

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Url.Action("Registros", "Persona");
            }
            Result = Redirect(returnUrl);


            return Result;

        }

        public ActionResult LogOff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult ExternalLinkLogin(string provider, string returnUrl)
        {
            string UserID = null;
            //obtenemos el identificador del usuario autenticado
            if (this.User.Identity.IsAuthenticated && User is ClaimsPrincipal)
            {
                var Identity = User as ClaimsPrincipal;
                var Claims = Identity.Claims.ToList();
                UserID = Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value;
            }
            //solicitamos el redirect al proveedor externo
            return new ChallengeResult(provider, Url.Action("ExternalLinkLoginCallback", "Account", new { ReturnUrl = returnUrl }), UserID);
        }

        public async Task<ActionResult> ExternalLinkLoginCallback()
        {

            try
            {

                ActionResult Result;
                // Obtener la información devuelta por el proveedor externo
                var LoginInfo =
                    await HttpContext.GetOwinContext().
                    Authentication.GetExternalLoginInfoAsync(
                        ChallengeResult.XsrfKey, User.Identity.GetUserId());

                if (LoginInfo == null)
                {
                    Result = Content("No se pudo realizar la autenticación con el proveedor externo");
                    return RedirectToAction("NotFound", "Error");
                }
                else
                {
                    // El usuario ha sido autenticado por el proveedor externo!
                    // Obtener la llave del proveedor de autenticación.
                    // Esta llave es específica del usuario.
                    string ProviderKey = LoginInfo.Login.ProviderKey;
                    // Obtener el nombre del proveedor de autenticación.
                    string ProviderName = LoginInfo.Login.LoginProvider;
                    // Enlazar los datos de la cuenta externa con la cuenta de usuario local. 
                    int IdUsuario = int.Parse(Funciones.GetClaimInfo(ClaimTypes.NameIdentifier));
                    ///aqui actualizo al usuario para el provider key 

                    return RedirectToAction("Registros", "Persona");
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.Message;
                return RedirectToAction("InternalServerError", "Error");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitamos un Redirect al proveedor externo.
            return new
                ChallengeResult(provider, Url.Action(
                    "ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            ActionResult Result;

            // Obtener la información devuelta por el proveedor externo
            var LoginInfo = await HttpContext.GetOwinContext().
                Authentication.GetExternalLoginInfoAsync();

            if (LoginInfo == null)
                // No se pudo autenticar.
                Result = RedirectToAction("Login", "Account");
            else
            {
                // El usuario ha sido autenticado por el proveedor externo!
                // Obtener la llave del proveedor que identifica al usuario.
                string ProviderKey = LoginInfo.Login.ProviderKey;
                ///consulto al usuario por el concepto de providerKey
                ///Result = SigInUser(User, false, returnUrl);
                Result = RedirectToAction("Login","Account");
            }
            return Result;
        }
    }
}