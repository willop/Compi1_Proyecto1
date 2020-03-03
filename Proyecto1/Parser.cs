using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Parser
    {

        List<Token> Listatokenslexico = new List<Token>();
        List<Error_Sintactico> Listaerrorsintactivo = new List<Error_Sintactico>();
        bool primeravez = true;
        int cantidaddeerroressintacticos = 0;
        int fila = 0;
        int columna = 0;
        int contador;
        Token tokenactual;

        public int parser(List<Token>_Lista)
        {
            Listatokenslexico = _Lista;
            contador = 0;
            tokenactual = Listatokenslexico[0];
            inicio();
            return cantidaddeerroressintacticos;
        }

        //metodos
        public void inicio()
        {
            if (tokenactual.idtoken.Equals("TK_{"))
            {
                //System.out.print("entro al inicio y reconocio {");
                match("TK_{");
                cuerpo();
                //System.out.print("llego al final");
                match("TK_}");

            }
            else
            {
                Listaerrorsintactivo.Add(new Error_Sintactico(tokenactual.idtoken, "Error sintactico", fila, columna));
                //System.err.print("errror en el analizadooooor sintactico");
            }
        }//fin de inicio

        public void cuerpo()
        {
            conjunto();
            Expresion();
        }

        public void conjunto()
        {
            if (tokenactual.idtoken.Equals("TK_conj"))
            {
                match("TK_conj");
                match("TK_:");
                match("TK_id");
                match("TK_apuntador");
                definicion();
                match("TK_pcoma");
                conjunto();
            }
            else
            {
                //epsilon
            }
        }

        public void definicion()
        {
            if (tokenactual.idtoken.Equals("TK_id"))
            {
                match("TK_id");
                alcance();
            }
            if (tokenactual.idtoken.Equals("TK_num"))
            {
                match("TK_num");
                alcance();
            }
            else
            {
                //error por que se necesia un id o un numero
            }
        }

        public void alcance()
        {
            if (tokenactual.idtoken.Equals("TK_coma"))
            {
                match("TK_coma");
                alcance2();

            }
            if (tokenactual.idtoken.Equals("TK_~"))
            {
                match("TK_~");
                alcance2();
            }
        }

        public void alcance2()
        {
            definicion();
        }

        public void difer()
        {
            if (tokenactual.idtoken.Equals("TK_:"))
            {
                match("TK_:");
                validacion();
            }
            else if (tokenactual.idtoken.Equals("TK_apuntador"))
            {
                match("TK_apuntador");
                ER();
            }
            else
            {
                //errorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
            }
        }

        public void Expresion()
        {
            if (tokenactual.idtoken.Equals("TK_id"))
            {
                match("TK_id");
                difer();
                match("TK_pcoma");
                //-----aca se obtiene la ER del archivo de entrada
                Expresion();

            }
            else
            {
                //epsilon
            }
        }

        public void ER()
        {
            if (tokenactual.idtoken.Equals("TK_punto"))
            {
                //se añade
                match("TK_punto");
                valI();
                valD();

            }
            else if (tokenactual.idtoken.Equals("TK_|"))
            {
                match("TK_|");
                valI();
                valD();

            }
            else if (tokenactual.idtoken.Equals("TK_*"))
            {
                match("TK_*");
                valI();
            }
            else if (tokenactual.idtoken.Equals("TK_?"))
            {
                match("TK_?");
                valI();
            }
            else if (tokenactual.idtoken.Equals("TK_+"))
            {
                match("TK_+");
                valI();
            }
            else
            {
                //error en la expresion
            }
        }

        public void valI()
        {
            if (tokenactual.idtoken.Equals("TK_num"))
            {
                //se agrega
                match("TK_num");

            }
            if (tokenactual.idtoken.Equals("TK_cadena"))
            {
                //se agrega
                match("TK_cadena");

            }
            if (tokenactual.idtoken.Equals("TK_compacto"))
            {
                //se agrega
                match("TK_compacto");

            }
            else
            {
                ER();
            }
        }

        public void valD()
        {
            if (tokenactual.idtoken.Equals("TK_num"))
            {
                //se agrega
                match("TK_num");

            }
            if (tokenactual.idtoken.Equals("TK_cadena"))
            {
                //se agrega
                match("TK_cadena");

            }
            if (tokenactual.idtoken.Equals("TK_compacto"))
            {
                //se agrega
                match("TK_compacto");

            }
            else
            {
                ER();
            }
        }


        public void validacion()
        {
            if (tokenactual.idtoken.Equals("TK_cadena"))
            {
                match("TK_cadena");
                validacion();
            }
            else
            {

            }
        }

        //metodo match
        public void match(string _token_enviado)
        {
            if (_token_enviado != tokenactual.idtoken)
            {
                Listaerrorsintactivo.Add(new Error_Sintactico(tokenactual.idtoken,"Se esperaba: "+_token_enviado,tokenactual.fila,tokenactual.columna));
                contador++;
                cantidaddeerroressintacticos++;
                tokenactual = Listatokenslexico[contador];
            }
            else if (_token_enviado!="fin")
            {
                //no hay error sintactico
                contador++;
                tokenactual = Listatokenslexico[contador];
            }

        }



        public List<Error_Sintactico> _listaerrores()
        {
            return Listaerrorsintactivo;
        }

    }
}
