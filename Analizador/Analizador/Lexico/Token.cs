using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador.Analizador
{
    class Token
    {
        string patron;
        string nombre;
        bool ignore;
        
        public Token(string patron, string nombre, bool ignore = false)
        {
            this.patron = patron;
            this.nombre = nombre;
            this.ignore = ignore;
        }

        public string getPatron()
        {
            return patron;
        }

        public string getNombre()
        {
            return nombre; 
        }

        public bool getIgnore()
        {
            return ignore;
        }

       

    }
}
