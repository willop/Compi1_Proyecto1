using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Error_Sintactico
    {
        public string caracter, descripcion;
        public int fila, columna;

        public Error_Sintactico(string _caracter,string _descripcion,int _fila, int _columna)
        {
            this.caracter = _caracter;
            this.descripcion = _descripcion;
            this.fila = _fila;
            this.columna = _columna;

        }
    }
}
