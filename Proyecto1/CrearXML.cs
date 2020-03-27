using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proyecto1
{
    class CrearXML
    {
        List<Token> listatokens;
        //constructor
        public CrearXML(List<Token> _lista)
        {
            this.listatokens = _lista;
            generarXML();
        }

        private void generarXML()
        {
            XmlDocument documento = new XmlDocument();
            //Lista_tokens
            XmlElement raiz = documento.CreateElement("Lista_Tokens");
            documento.AppendChild(raiz);
            XmlElement token;//= documento.CreateElement("Token");
            XmlElement nombre;// = documento.CreateElement("Nombre_token");
            XmlElement valor;// = documento.CreateElement("Valor_token");
            XmlElement fila;// = documento.CreateElement("Fila_token");
            XmlElement columna;// = documento.CreateElement("Columna_token");

            for (int i = 0; i < listatokens.Count-1; i++)
            {
                token = documento.CreateElement("Token");
                raiz.AppendChild(token);
                nombre = documento.CreateElement("Nombre");
                nombre.AppendChild(documento.CreateTextNode(listatokens[i].idtoken));
                valor = documento.CreateElement("Valor_token");
                valor.AppendChild(documento.CreateTextNode(listatokens[i].lexema));
                fila = documento.CreateElement("Fila_token");
                fila.AppendChild(documento.CreateTextNode(listatokens[i].fila.ToString()));
                columna = documento.CreateElement("Columna_token");
                columna.AppendChild(documento.CreateTextNode(listatokens[i].columna.ToString()));
                
                token.AppendChild(nombre);
                token.AppendChild(valor);
                token.AppendChild(fila);
                token.AppendChild(columna);
            }
            documento.Save("C:\\Users\\Wilfred\\Desktop\\AC1\\ListaTokens.xml");

        }
    }
}
