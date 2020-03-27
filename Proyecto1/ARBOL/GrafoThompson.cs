using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto1.ARBOL
{
    class GrafoThompson
    {
        public StreamWriter archivo;
        private string contenidogv;
        private List<Token> gramatica;
        int contador = 0;
        int fin;
        int contadorsiguiente;
        int ultimocontador;

        int contadornodos = 0;


        List<Token> getGramatica()
        {
            return this.gramatica;
        }
        void setGramatica(List<Token> _gramatica)
        {
            this.gramatica = _gramatica;
        }
        string getcontenido()
        {
            return this.contenidogv;
        }
        void setAddContenido(string _contenido)
        {
            this.contenidogv += _contenido;
        }


        //constructor
        public GrafoThompson(List<Token> _gramatica)
        {
            this.gramatica = _gramatica;
            setAddContenido("Digraph g{\nrankdir=LR;\n");
            graficarPorSimbolo();
            //fin del gvdit
            setAddContenido("\n}");

            archivo = new StreamWriter(@"C:\Users\Wilfred\Desktop\grafoThompson.txt");
            archivo.WriteLine(getcontenido());
            archivo.Close();
        }

        public void graficarPorSimbolo()
        {
            try
            {
                //punto
                if (getGramatica()[contador].idtoken.Equals("TK_|"))
                {
                    int inicio = contadornodos;
                    contador++;
                    ultimocontador = contador;
                    contadorsiguiente = contadornodos + 1;
                    setAddContenido(inicio + "->" + contadorsiguiente + "[label=\"E\"];\n");
                    contadornodos++;
                    contadorsiguiente = contadornodos + 1;



                    if (getGramatica()[contador].idtoken != "TK_|")
                    {
                        setAddContenido(contadornodos + "->" + contadorsiguiente + "[label=\"" + getGramatica()[contador].lexema + "\"];\n");
                        contador++;
                        ultimocontador = contador;
                        contadornodos++;
                        contadorsiguiente = contadornodos + 1;

                        setAddContenido(contadornodos + "->" + contadorsiguiente + "[label=\"E\"];\n");
                        contadornodos++;
                        fin = contadornodos;

                    }
                    if (getGramatica()[contador].idtoken == "TK_|")
                    {
                        graficarPorSimbolo();
                    }


                    contadornodos++;
                    contadorsiguiente = contadornodos + 1;

                    setAddContenido(inicio + "->" + contadornodos + "[label=\"E\"];\n");

                    if (getGramatica()[contador].idtoken != "TK_|")
                    {
                        setAddContenido(contadornodos + "->" + contadorsiguiente + "[label=\"" + getGramatica()[contador].lexema + "\"];\n");
                        contador++;
                        contadornodos++;

                    }

                    setAddContenido(contadornodos + "->" + fin + "[label=\"E\"];\n");


                }
            }
            catch
            {

            }

        }

        public void graficaPorCaracter()
        {

        }


    }
}
