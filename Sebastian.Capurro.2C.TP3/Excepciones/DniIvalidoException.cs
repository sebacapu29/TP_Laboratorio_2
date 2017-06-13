using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniIvalidoException:Exception
    {
        private string _mensajeBase;

        public DniIvalidoException():base()
        {
        }
        public DniIvalidoException(Exception e):base()
        {
            this._mensajeBase = e.Message;
        }
        public DniIvalidoException(string message):base(message)
        {
        }
        public DniIvalidoException(string message, Exception e):base(message,e)
        { 
        }
    }
}
