using PruebaJOIN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace PruebaJOIN.Controllers
{
    public class UsuarioxCiudadController : Controller
    {

        // GET: UsuarioxCiudad
        public ActionResult Index()
        {
            try {
                using (PruebaJOINEntities_Context db = new PruebaJOINEntities_Context()) {


                    //List<UsuarioXCiudad> data = db.UsuarioXCiudad.ToList();
                    var data = (from userciu in db.UsuarioXCiudad
                                join user in db.Usuario
                                 on userciu.IdUser equals user.IdUser
                                join ciu in db.Ciudad
                                 on userciu.IdCiudad equals ciu.IdCiudad
                                select new UsuarioXCiudadCE{
                                    Id = userciu.Id,
                                    IdCiudad = userciu.IdCiudad,
                                    IdUser = userciu.IdUser,
                                    Obervaciones = userciu.Obervaciones,
                                    NombreUsuario = user.NombreUsuario,
                                    NombreCiudad = ciu.NombreCiudad
                                    
                                });


                    return View(data.ToList());
                }

            } catch (Exception Error) {
                ModelState.AddModelError("Error al momento de listar ", Error);
                //MessageBox.Show(Error.Message.ToString());
                return View();
            }
        }

        /** Crear **/
        [HttpGet]
        public  ActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(UsuarioXCiudadCE userciu) {
            if (!ModelState.IsValid) {
                return View();
            }
            try {

                using (var db = new PruebaJOINEntities_Context()) {
                    db.CrearUserCiu(userciu.Obervaciones, userciu.NombreCiudad, userciu.NombreUsuario);
                    //db.CrearUserCiu1(userciu.NombreCiudad, userciu.NombreUsuario);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            } catch (Exception Error) {
                //MessageBox.Show(Error.Message.ToString());
                ModelState.AddModelError("", "Error al Crear " + Error.Message);
                return View();
            }

        }

        /** Editar **/
        public ActionResult Editar(int id) 
        {
            try {
                using (var db = new PruebaJOINEntities_Context()) {
                    //Usar where en caso que la llave no sea unica
                    //UsuarioXCiudad userciu1 = db.UsuarioXCiudad.Where(a => a.Id == id).FirstOrDefault();
                   
                    UsuarioXCiudad userciu2 = db.UsuarioXCiudad.Find(id);
                    Usuario user = db.Usuario.Find(userciu2.IdUser);
                    Ciudad ciudad = db.Ciudad.Find(userciu2.IdCiudad);

                    var userciuCE = new UsuarioXCiudadCE {
                        Id = userciu2.Id,
                        IdCiudad = userciu2.IdCiudad,
                        IdUser = userciu2.IdUser,
                        Obervaciones = userciu2.Obervaciones,
                        NombreUsuario = user.NombreUsuario,
                        NombreCiudad = ciudad.NombreCiudad

                    };
                    return View(userciuCE);
                }

            } catch (Exception error) {
                ModelState.AddModelError("", "Error al Editar " + error.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(UsuarioXCiudadCE userciuForm) {
            if (!ModelState.IsValid) {
                return View();
            }
            try {

                using (var db = new PruebaJOINEntities_Context()) {

                    /*UsuarioXCiudad userciuDB = db.UsuarioXCiudad.Find(userciuForm.Id);
                    Usuario userDB = db.Usuario.Find(userciuDB.IdUser);
                    Ciudad ciudadDB = db.Ciudad.Find(userciuDB.IdCiudad);

                    //userDB.NombreUsuario = userciuForm.NombreUsuario;
                    //ciudadDB.NombreCiudad = userciuForm.NombreCiudad;

                    //userciuBD.IdCiudad = userciuForm.IdCiudad;
                    //userciuBD.IdUser = userciuForm.IdUser;
                    //userciuDB.Obervaciones = userciuForm.Obervaciones;*/

                    db.InsertarUserCiu(userciuForm.IdCiudad, userciuForm.IdUser, userciuForm.Obervaciones, userciuForm.NombreCiudad, userciuForm.NombreUsuario);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            } catch (Exception Error) {
                //MessageBox.Show(Error.Message.ToString());
                ModelState.AddModelError("", "Error al Editar " + Error.Message);
                return View();
            }
        }

        public ActionResult DetallesUserciu(int id) {
            try {

                using (var db = new PruebaJOINEntities_Context()) {

                    UsuarioXCiudad userciu2 = db.UsuarioXCiudad.Find(id);
                    Usuario user = db.Usuario.Find(userciu2.IdUser);
                    Ciudad ciudad = db.Ciudad.Find(userciu2.IdCiudad);

                    var userciuCE = new UsuarioXCiudadCE {
                        Id = userciu2.Id,
                        IdCiudad = userciu2.IdCiudad,
                        IdUser = userciu2.IdUser,
                        Obervaciones = userciu2.Obervaciones,
                        NombreUsuario = user.NombreUsuario,
                        NombreCiudad = ciudad.NombreCiudad

                    };
                    return View(userciuCE);
                }

            } catch (Exception Error) {
                //MessageBox.Show(Error.Message.ToString());
                ModelState.AddModelError("", "Error al mostrar detalles " + Error.Message);
                return View();
            }
        }

        public ActionResult EliminarUserCiu(int id) {

            try {

                using (var db = new PruebaJOINEntities_Context()) {

                    UsuarioXCiudad userciu2 = db.UsuarioXCiudad.Find(id);
                    Usuario user = db.Usuario.Find(userciu2.IdUser);
                    Ciudad ciudad = db.Ciudad.Find(userciu2.IdCiudad);

                    db.Usuario.Remove(user);
                    db.Ciudad.Remove(ciudad);
                    db.UsuarioXCiudad.Remove(userciu2);

                    db.SaveChanges();


                    return RedirectToAction("Index");
                }

            } catch (Exception Error) {
                //MessageBox.Show(Error.Message.ToString());
                ModelState.AddModelError("", "Error al eliminar " + Error.Message);
                return View();
            }
        }
    }
}