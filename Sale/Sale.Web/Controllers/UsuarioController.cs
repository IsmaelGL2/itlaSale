using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Contracts;
using Sale.Application.Core;
using Sale.Application.Dtos.Usuario;

namespace Sale.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;


        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var result = this.usuarioService.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.usuarioService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
        public ActionResult Create(UsuarioDtoAdd usuarioDtoAdd)
        {
            ServicesResult result = new ServicesResult();

            try
            {

                result = this.usuarioService.Save(usuarioDtoAdd);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }



        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.usuarioService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = (UsuarioDtoGetAll)result.Data;

            UsuarioDtoUpdate usuarioDto = new UsuarioDtoUpdate()
            {
                //IdRol = datos.UsuarioId,
                //EnrollmentDate = datos.EnrollmentDate,
                Nombre = datos.Nombre,
            };

            return View(usuarioDto);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDtoUpdate usuarioDtoUpdate)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result = this.usuarioService.Update(usuarioDtoUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }



        // GET: UsuarioController/Delete/5



    }
}

