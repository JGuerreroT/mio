using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Helper;
using System.Data.Entity;
using ManejadorErrores;

namespace Model
{
    public class PersonaBL
    {

        public ResponseModel Guardar(tb_Persona persona)
        {
            var rm = new ResponseModel();
            var codigo = 0;

            try
            {
                using (var ctx = new SeguroContext())
                {
                    if (persona.idPersona > 0)
                    {
                        ctx.Entry(persona).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(persona).State = EntityState.Added;
                    }
                    ctx.SaveChanges();

                    codigo = persona.idPersona;

                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return rm;
        }

        public int GuardarPersona(tb_Persona persona)
        {
            var codigo = 0;

            try
            {
                using (var ctx = new SeguroContext())
                {
                    if (persona.idPersona > 0)
                    {
                        ctx.Entry(persona).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(persona).State = EntityState.Added;
                    }
                    ctx.SaveChanges();

                    codigo = persona.idPersona;
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return codigo;
        }


    }
}
