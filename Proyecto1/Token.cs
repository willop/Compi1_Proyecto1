using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Token
    {
        string idtoken,lexema, tipo;
        int fila, columna;

        public Token(string _idtoken,string _lexema, string _tipo,int _fila, int _columna)
        {
            this.idtoken = _idtoken;
            this.lexema = _lexema;
            this.tipo = _tipo;
            this.fila = _fila;
            this.columna = _columna;
        }
    }
}
