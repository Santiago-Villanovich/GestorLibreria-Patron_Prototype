using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace Servicio
{
    public class SessionManager
    {
        private static object _lock = new Object();
        private static SessionManager _session;
        public BLLUsuario Usuario { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) _session = new SessionManager();

                return _session;
            }
        }

        public static void Login(BLLUsuario usuario)
        {

            lock (_lock)
            {
                if (_session != null)
                {
                    _session.Usuario = usuario;
                  //  _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("No hay sesion iniciada");
                }
            }
        }
        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }


        }

        public static bool TraerUsuario()
        {
            if (_session != null)
            {
                return _session.Usuario != null;
            }
            return false;
        }

    }
}
