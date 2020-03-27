using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto1
{
    class HTMLErrores
    {
        List<ErrorToken> listaerrores;

        public HTMLErrores(List<ErrorToken> _lista)
        {
            this.listaerrores = _lista;
            crearErrorHTML();

        }

        private void crearErrorHTML()
        {
            try
            {
                string path = "C:\\Users\\Wilfred\\Desktop\\AC1\\ErroresLexicos.html";
                StreamWriter sr = new StreamWriter(path);
                int contador = listaerrores.Count;
                sr.WriteLine("<html> <head><title> Lista de errores </title></head><body><br><br><br><br><center><table border = 5 WIDTH = \"65%\" ><tbody>    <tr bgcolor = \"red\">  <th colspan = 5>**Lista de Errores HTML**</th>    </tr>    <tr>    <th width=\"10%\"> No.</th>    <th>Error </th>  <th> Descripcion </th>  <th width=\"10%\"> fila </th>  <th width=\"10%\"> Columna </th>  </tr><br><br><br><br><br><br><br><br>");
                foreach (ErrorToken lista in listaerrores)
                {
                    sr.WriteLine("<tr>    <th>" + contador + "</th>    <th>" + lista.lexema + "</th>  <th>" + lista.lexema + " </th>  <th>" + lista.fila + "</th>  <th>" + lista.columna + "</th>   </tr>");
                }
                sr.WriteLine("</tbody></table></center ></body></html>");
                sr.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
