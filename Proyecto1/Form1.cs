using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        //*************************************************variables globales
        string rutaarchivo,palabra;
        List<Token> listatokens = new List<Token>();
        List<ErrorToken> listaerrorlexico = new List<ErrorToken>();


        public Form1()
        {
            InitializeComponent();
        }

        private void agregarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////------------------------------------------ crear una pestaña con un richtextbox dentro ---------------------------------------------
            int cantpaginas;
            cantpaginas = tabControl1.TabPages.Count + 1;
            TabPage nuevapestaña = new TabPage("Pestaña " + cantpaginas);
            RichTextBox cajatexto = new RichTextBox();
            cajatexto.SetBounds(10, 10, 377, 463); //401; 495
            cajatexto.WordWrap = false;
            cajatexto.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            nuevapestaña.Controls.Add(cajatexto);
            tabControl1.TabPages.Add(nuevapestaña);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listatokens.Clear();
            listaerrorlexico.Clear();

            TabPage tp = tabControl1.SelectedTab; //obtiene la pagina actual
            RichTextBox contenedortexto = new RichTextBox(); //objeto para obtener el texto de el contenedor en la pestaña
            contenedortexto = tp.Controls[0] as RichTextBox; //se obtiene las propiedades del richtextbox               
            palabra = "";


            int longitudcodigo, fila, columna;
            int estado = 0;
            fila = 0;
            columna = 0;
            String codigo;
            codigo = contenedortexto.Text;
            longitudcodigo = codigo.Length;

            //inicia el analizador lexico
            for (int contador = 0; contador < longitudcodigo; contador++)
            {
                switch (estado)
                {
                    //----------------------------estado 0
                    case 0:
                        {
                            //----------}
                            if (codigo[contador].Equals((char)125))
                            {
                                estado = 0;
                                columna++;
                                listatokens.Add(new Token("TK_}",codigo[contador].ToString(),"Corchete de cierre",fila,columna));
                                break;
                            }
                            //----------{
                            if (codigo[contador].Equals((char)123))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 30;
                                break;
                            }
                            //------------si son dos puntos 
                            if (codigo[contador].Equals((char)58))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_:",codigo[contador].ToString(),"Token dos puntos",fila,columna));
                                break;

                            }
                            //--------------si es una coma ,
                            if (codigo[contador].Equals((char)44))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_coma",codigo[contador].ToString(), "Token coma", fila, columna));
                                break;
                            }
                            //--------------si es un punto y coma
                            if (codigo[contador].Equals((char)59))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_pcoma",codigo[contador].ToString(),"Token punto y coma",fila ,columna));
                                break;
                            }
                            //-------------------si es un punto
                            if (codigo[contador].Equals((char)46))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_punto", codigo[contador].ToString(), "Token punto", fila, columna));
                                break;
                            }
                            //---------------------si es un signo de interrogación ?
                            if (codigo[contador].Equals((char)63))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_?", codigo[contador].ToString(), "Token cerradura ?", fila, columna));
                                break;
                            }
                            //-----------------------si es un signo +
                            if (codigo[contador].Equals((char)43))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_+", codigo[contador].ToString(), "Token cerradura +", fila, columna));
                                break;
                            }
                            //-----------------------------si es un porcentaje %
                            if (codigo[contador].Equals((char)37))
                            {
                                columna++;
                                //no lo agrego ya que en el analizador sintactico no tiene relevancia
                                //listatokens.Add(new Token("TK_pcoma", codigo[contador].ToString(), "Token punto y coma", fila, columna));
                                break;
                            }
                            //-----------------------------si es un *
                            if (codigo[contador].Equals((char)42))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_*", codigo[contador].ToString(), "Token cerradura *", fila, columna));
                                break;
                            }
                            //--------------------------- si es el guion de la ñ 126 ~
                            if (codigo[contador].Equals((char)126))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_~", codigo[contador].ToString(), "Token ~", fila, columna));
                                break;
                            }
                            //----------------------------- si es menor <
                            if (codigo[contador].Equals((char)60))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 1;
                                break;
                            }
                            //---------------------------------si es una letra
                            if (char.IsLetter(codigo[contador]))
                            {
                                columna++;
                                palabra += palabra;
                                estado = 2;
                                break;
                            }
                            //----------------------- sin son comillas dobles "
                            if (codigo[contador].Equals((char)34))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 3;
                                break;
                            }
                            //-------------------si es un digito
                            if (char.IsDigit(codigo[contador]))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 4;
                                break;
                            }
                            //-----------------------para una diagonal
                            if (codigo[contador].Equals((char)47))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 13;
                                break;
                            }
                            //-----------------------si es un guion para el apuntado ->
                            if (codigo[contador].Equals((char)45))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 10;
                                break;

                            }
                            //----------------------si es un | operador o
                            if (codigo[contador].Equals((char)124))
                            {
                                columna++;
                                listatokens.Add(new Token("TK_|", codigo[contador].ToString(), "Token operador |", fila, columna));
                                break;
                            }
                            //**********************************************************por defecto**************************************
                            //---------------------si es un salto de linea
                            if (codigo[contador].Equals((char)10))
                            {
                                columna = 0;
                                fila++;
                                break;
                            }
                            //---------------------si es una tabulacion
                            if (codigo[contador].Equals((char)09))
                            {
                                columna += 8;
                                break;

                            }
                            //**************************************errores ************************************
                            else
                            {
                                columna++;
                                listaerrorlexico.Add(new ErrorToken(codigo[contador].ToString(), "Caracter desconocido", fila, columna));
                            break;
                            }
                        }//----------------fin estado 0

                        //estado 1
                    case 1:
                        {   
                            //si es !
                            if (codigo[contador].Equals((char)33))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 6;
                                
                            }
                            break;
                        }//-----------------------fin del estado 1


                        //------ estado  2
                    case 2:
                        {
                            if (char.IsLetter(codigo[contador]) || char.IsDigit(codigo[contador]))
                            {
                                palabra += codigo[contador];
                                columna++;
                                break;
                            }
                            else
                            {
                                if (palabra.Equals("CONJ"))
                                {
                                    listatokens.Add(new Token("TK_conj",palabra,"Palabra reservada CONJ",fila,columna));
                                    
                                }
                                else
                                {
                                    listatokens.Add(new Token("TK_id",palabra,"Identificador",fila,columna ));
                                }
                                contador--;
                                palabra = "";
                                estado = 0;
                            }
                            break;

                        }//--------------------fin del estado 2


                        //------------------estado 30-------
                    case 30:
                        {
                            //si es corchetes de cierre }
                            if (codigo[contador].Equals((char)125))
                            {
                                contador--;
                                estado = 12;
                                palabra = "";
                            }
                            //------- si viene un espacio en blanco o un salto de linea quiere decir que solo es el corchete
                            else if (codigo[contador].Equals((char)10)||codigo[contador].Equals((char)32))
                            {
                                listatokens.Add(new Token("TK_{",palabra,"Corchetes de apertura",fila,columna));
                                contador--;
                                palabra = "";
                                estado = 0;

                            }
                            else
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 30;
                            }
                            break;
                        }//----------fin del estado 30

                    case 3:
                        {
                            //---almacena cualquier cosa dentro de las comillas
                            if (codigo[contador].Equals((char)34))
                            {
                                contador--;
                                estado = 12;
                                break;
                            }
                            else
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 3;
                                break;
                            }                            
                        }//----------------fin del estado 3

                        //estado 4 para digitos
                    case 4:
                        {
                            if (char.IsDigit(codigo[contador]))
                            {
                                palabra += codigo[contador];
                                columna++;
                                estado = 4;
                                break;
                            }
                            else
                            {
                                listatokens.Add(new Token("TK_num",palabra,"Numero entero",fila,columna));
                                contador--;
                                palabra = "";
                                estado = 0;
                                break;
                            }
                        }//-------------------fin del estado 4


                        //estado para capturar cualquier cosa
                    case 6:
                        {
                            //------------- para terminar el comentario multilinea
                            if (codigo[contador].Equals((char)33))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 7;
                                break;
                            }
                            //si es un salto de linea
                            else if (codigo[contador].Equals((char)10))
                            {
                                columna = 0;
                                fila++;
                                palabra += codigo[contador];
                                estado = 6;
                                break;
                            }
                            else
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 6;
                                break;
                            }
                        }// fin del estado 6

                        //estado 7 fin del comentario multilinea
                    case 7:
                        {
                            //----  si es mayor >
                            if (codigo[contador].Equals((char)62))
                            {
                                estado = 9;
                                contador--;
                            }
                            else
                            {
                                estado = 6;
                                contador--;
                            }
                            break;
                        }//------- fin del estado 7


                        // estado 9
                    case 9:
                        {
                            columna++;
                            palabra += codigo[contador];
                            listatokens.Add(new Token("TK_comentario", palabra, "Comentario multilinea", fila, columna));
                            estado = 0;
                            palabra = "";
                            break;
                        }//fin del estado 9


                        //estado 10
                    case 10:
                        {
                            if (codigo[contador].Equals((char)62))
                            {
                                contador--;
                                estado = 11;
                                break;
                            }
                            break;
                        }//fin del estado 10


                        //estado 11
                    case 11:
                        {
                            columna++;
                            palabra += codigo[contador];
                            listatokens.Add(new Token("TK_apuntador",palabra,"apuntador ->",fila,columna));
                            palabra = "";
                            estado = 0;
                            break;
                        }// fin del estado 11


                        //comienza estado 12
                    case 12:
                        {
                            //si son comillas
                            if (codigo[contador].Equals((char)34))
                            {
                                columna++;
                                palabra += codigo[contador];
                                listatokens.Add(new Token("TK_cadena", palabra, "Cadena de caracteres", fila, columna));
                                palabra = "";
                                estado = 0;
                                break;
                            }
                            if (codigo[contador].Equals((char)125))
                            {
                                columna++;
                                palabra += codigo[contador];
                                listatokens.Add(new Token("TK_compacto", palabra, "Cadena de texto dentro de {***}",fila,columna));
                                palabra = "";
                                estado = 0;
                                break;
                            }
                            break;
                        }//fin estado 12

                    //------ estado 13-----------
                    case 13:
                        {
                            // si es una diagonal
                            if (codigo[contador].Equals((char)47))
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 14;
                                break;
                            }
                            else
                            {
                                contador--;
                                listatokens.Add(new Token("TK_/", palabra, "Signo de divicion /", fila, columna));
                                palabra = "";
                                estado = 0;
                                break;
                            }

                        }//-------------fin del estado 13

                        //  inicio del estado 14
                    case 14:
                        {
                            //si es un salto de linea
                            if (codigo[contador].Equals((char)34))
                            {
                                columna = 0;
                                fila++;
                                //listatokens.Add(new Token("TK_comentario",palabra,"comentario de una linea ", fila, columna));

                                palabra = "";
                                estado = 0;
                                break;
                            }
                            else
                            {
                                columna++;
                                palabra += codigo[contador];
                                estado = 14;
                                break;
                            }
                        }// fin del estado 14

                }//**************fin del switch
            }//********fin del for del analizador lexico


        }



        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                TabPage tp = tabControl1.SelectedTab; //obtiene la pagina actual
                RichTextBox contenedortexto = new RichTextBox(); //objeto para obtener el texto de el contenedor en la pestaña
                contenedortexto = tp.Controls[0] as RichTextBox;

                if (rutaarchivo == "")
                {
                    SaveFileDialog cuadroguardar = new SaveFileDialog();
                    cuadroguardar.InitialDirectory = @"C:";
                    cuadroguardar.ShowDialog();

                    if (cuadroguardar.FileName != "")
                    {
                        //MessageBox.Show("entro por que se selecciono y la ruta es: "+cuadroguardar.FileName+"\ny escribira:\n"+contenedortexto.Text);
                        StreamWriter textoguardar = new StreamWriter(cuadroguardar.FileName);
                        rutaarchivo = cuadroguardar.FileName.ToString();
                        textoguardar.Write(contenedortexto.Text);
                        textoguardar.Close();
                    }

                }
                else
                {
                    StreamWriter textoguardar = new StreamWriter(rutaarchivo);
                    textoguardar.Write(contenedortexto.Text);
                    textoguardar.Close();
                }

            }
            catch (Exception)
            {


            }
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int cantidad;
            cantidad = tabControl1.TabPages.Count;

            if (cantidad == 0)
            {
                int cantpaginas;
                cantpaginas = tabControl1.TabPages.Count;
                TabPage nuevapestaña = new TabPage("Pestaña " + cantpaginas);
                RichTextBox cajatexto = new RichTextBox();
                cajatexto.SetBounds(10, 10, 380, 480);
                cajatexto.WordWrap = false;
                cajatexto.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
                nuevapestaña.Controls.Add(cajatexto);
                tabControl1.TabPages.Add(nuevapestaña);
                String contenido;

                //--------------------------------abrir el explorador----------------------------------------

                OpenFileDialog cuadrodialogo = new OpenFileDialog();
                cuadrodialogo.InitialDirectory = @"C:\Users\WillOP\Desktop";
                if (cuadrodialogo.ShowDialog() == DialogResult.OK)
                {

                    StreamReader sr = new StreamReader(cuadrodialogo.FileName, System.Text.Encoding.UTF8, false);
                    rutaarchivo = cuadrodialogo.FileName.ToString();
                    //MessageBox.Show(rutaarchivo);
                    contenido = sr.ReadToEnd();
                    cajatexto.Text = contenido;
                    sr.Close();
                }
            }
            else
            {
                TabPage tp = tabControl1.SelectedTab; //obtiene la pagina actual
                RichTextBox cajatexto = new RichTextBox(); //objeto para obtener el texto de el contenedor en la pestaña
                cajatexto = tp.Controls[0] as RichTextBox; //se obtiene las propiedades del richtextbox
                String contenido;
                //--------------------------------abrir el explorador----------------------------------------
                OpenFileDialog cuadrodialogo = new OpenFileDialog();
                cuadrodialogo.InitialDirectory = @"C:\Users\WillOP\Desktop\Archivos practica 1";
                if (cuadrodialogo.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(cuadrodialogo.FileName, System.Text.Encoding.UTF8, false);
                    rutaarchivo = cuadrodialogo.FileName.ToString();
                    //MessageBox.Show(rutaarchivo);
                    contenido = sr.ReadToEnd();
                    cajatexto.Text = contenido;
                    sr.Close();
                }
            }
        }
    }
}
