using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repositorio;
using Helper;
using ManejadorErrores;

namespace Model
{
    public class IpcBL
    {

        public tb_IPC ObtenerIPC(DateTime fechaIpc)
        {
            var ipc = new tb_IPC();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    ipc = ctx.tb_IPC
                        .Where(x => x.FechaIPC == fechaIpc)
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return ipc;
        }

    }
}
