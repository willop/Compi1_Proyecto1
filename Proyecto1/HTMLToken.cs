using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto1
{
    class HTMLToken
    {
        List<Token> lista;
        public HTMLToken(List<Token> _lista)
        {
            this.lista = _lista;
            crearHTML();
        }

        private void crearHTML()
        {
            string path = @"C:\\Users\\Wilfred\\Desktop\\AC1\\Tokens.html";
            StreamWriter creardoc = new StreamWriter(path);
            creardoc.WriteLine("<html><head><title> Archivo de tokens </title ></head ><body><br><br><br><br><center><table border = 5 WIDTH = \"65%\" ><tbody>    <tr bgcolor = \"skyblue\">  <th colspan = 5> Tabla de Tokens Proyecto Compiladores 1 </th>    </tr>    <tr>    <th width=\"10%\"> No.</th>    <th> Lexema </th>  <th > Tipo </th>  <th> Fila </th>  <th> Columna </th>   </tr>");
            int contador = 0;
            foreach (Token item in lista)
            {
                contador++;
                creardoc.WriteLine("<tr>    <th>" + contador + "</th>    <th>" + item.lexema + "</th>  <th>" + item.tipo + " </th>  <th>" + item.fila + "</th>   <th>" + item.columna + "</th> </tr>");
            }
            creardoc.WriteLine("</tbody></table></center ></body></html>");
            creardoc.Close();
        }
    }
}
