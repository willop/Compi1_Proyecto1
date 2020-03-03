using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class ErrorToken
    {
        string lexema, info;
        int fila, columna;
        //***********constructor******************
        public ErrorToken(string _lexema, string _info,int _fila,int _columna)
        {
            this.lexema = _lexema;
            this.info = _info;
            this.fila = _fila;
            this.columna = _columna;
        }
    }
}
