using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Repositorio;
using Helper;
using System.Data.Entity;
using Seguridad;
using ManejadorErrores;

namespace Model
{
    public class UsuarioBL
    {
        public ResponseModel Acceder(string Login, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx=new SeguroContext())
                {
                    Password = HashHelper.MD5(Password);
                    
                    var usuario = ctx.tb_Usuario
                                    .Where(x => x.Login == Login)
                                    .Where(x => x.Password == Password)
                                    //.Where(x => x.IdEstado == 1)
                                    .SingleOrDefault();

                    if (usuario != null)
                    {
                        if (usuario.IdEstado == 1)
                        {
                            SessionHelper.AddUserToSession(usuario.IdUsuario.ToString());
                            rm.SetResponse(true);
                        }
                        else
                        {
                            rm.SetResponse(false, "Usuario Bloqueado");
                        }
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                        //rm.SetResponse(false, " ");
                        //rm.response = false;
                        BloqueoUsuario(Login);
                    }
                }
            }
            catch (Exception e)
            {
                ELog.save(this, e); //throw;
            }

            return rm;
        }

        public tb_Usuario ObtenerUsuario(int idUsuario)
        {
            var usuario = new tb_Usuario();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    usuario = ctx.tb_Usuario
                        .Where(x => x.IdUsuario == idUsuario)
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return usuario;
        }

        public ResponseModel BloquearUsuario(string Login)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new SeguroContext())
                {
                    var usuario = ctx.tb_Usuario
                                    .Where(x => x.Login == Login)
                                    .SingleOrDefault();

                    if (usuario != null)
                    {
                        usuario.IdEstado = 6;
                        ctx.Entry(usuario).State = EntityState.Modified;
                        rm.SetResponse(false, "Usuario Bloqueado");
                        ctx.SaveChanges();
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                    }
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return rm;
        }

        public ResponseModel BloqueoUsuario(string Login)
        {
            var rm = new ResponseModel();
            rm.bloqueo = false;

            try
            {
                if (SessionHelper.GetUser() == 0)
                {
                    rm.SetResponse(false, "Correo o contraseña incorrecta");
                    SessionHelper.AddUserToSession("1");
                }
                else
                {
                    var contador = SessionHelper.GetUser() + 1;
                    SessionHelper.DestroyUserSession();

                    if (contador == 3)
                    {
                        rm = BloquearUsuario(Login);
                        //rm.SetResponse(false, "Usuario Bloqueado");
                        //rm.href = Url.Content("~/");
                        rm.bloqueo = true;
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                        SessionHelper.AddUserToSession(contador.ToString());
                    }

                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }
                        
            return rm;
        }

    }
}
