using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proyecto1
{
    class CrearXMLErrores
    {
        List<ErrorToken> listaerrores;

        public CrearXMLErrores(List<ErrorToken> _lista)
        {
            this.listaerrores = _lista;
            CrearXMLERRORES();

        }
        private void CrearXMLERRORES()
        {
            XmlDocument archivoerrores = new XmlDocument();
            XmlElement raiz = archivoerrores.CreateElement("Errores_lexicos");
            archivoerrores.AppendChild(raiz);
            XmlElement Error;
            XmlElement valor;
            XmlElement fila;
            XmlElement columna;

            for (int i = 0; i < listaerrores.Count; i++)
            {
                Error = archivoerrores.CreateElement("Error");
                raiz.AppendChild(Error);
                valor = archivoerrores.CreateElement("Valor_Error");
                valor.AppendChild(archivoerrores.CreateTextNode(listaerrores[i].lexema));
                fila = archivoerrores.CreateElement("Fila_Error_lexico");
                fila.AppendChild(archivoerrores.CreateTextNode(listaerrores[i].fila.ToString()));
                columna = archivoerrores.CreateElement("Columna_Error_lexico");
                columna.AppendChild(archivoerrores.CreateTextNode(listaerrores[i].columna.ToString()));
                Error.AppendChild(valor);
                Error.AppendChild(fila);
                Error.AppendChild(columna);
            }
            archivoerrores.Save("C:\\Users\\Wilfred\\Desktop\\AC1\\Errores_lexicos.xml");
        }
    }
}
