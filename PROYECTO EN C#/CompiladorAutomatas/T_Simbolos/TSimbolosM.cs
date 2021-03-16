using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Simbolos
{
    public class T_SimbolosM
    {
        public List<Constructor_Tsimbolos> tSimbolos = new List<Constructor_Tsimbolos>();
        public List<Complete> datos = new List<Complete>();
        public T_SimbolosM() { }
        public List<Constructor_Tsimbolos> TSimbolos { get => tSimbolos; set => tSimbolos = value; }

        public void Tokens()
        {
            //(int iD_Token, string token, string tipo, string descripcion_Tipo)
            Constructor_Tsimbolos tk = new Constructor_Tsimbolos(0, "<<", "Comentario", " Inicio de una linea de comentario ");
            tSimbolos.Add(tk);
            Constructor_Tsimbolos tk1 = new Constructor_Tsimbolos(1, ">>", "Comentario", " Fin de una linea de comentario ");
            tSimbolos.Add(tk1);
            Constructor_Tsimbolos tk2 = new Constructor_Tsimbolos(2, "<¿", "Comentario", " Inicio de mas de una linea de comentario ");
            tSimbolos.Add(tk2);
            Constructor_Tsimbolos tk3 = new Constructor_Tsimbolos(3, "<?", "Comentario", " Fin de mas de una linea de comentario ");
            tSimbolos.Add(tk3);
            Constructor_Tsimbolos tk4 = new Constructor_Tsimbolos(4, "{", "Bloque", " Inicio de un bloque ");
            tSimbolos.Add(tk4);
            Constructor_Tsimbolos tk5 = new Constructor_Tsimbolos(5, "}", "Bloque", " Fin de un bloque ");
            tSimbolos.Add(tk5);
            Constructor_Tsimbolos tk6 = new Constructor_Tsimbolos(6, ">int", "Palabra reservada", " Numero entero ");
            tSimbolos.Add(tk6);
            Constructor_Tsimbolos tk7 = new Constructor_Tsimbolos(7, ">double", "Palabra reservada", " Numero con decimales ");
            tSimbolos.Add(tk7);
            Constructor_Tsimbolos tk8 = new Constructor_Tsimbolos(8, ">string", "Palabra reservada", " Cadena de caracteres ");
            tSimbolos.Add(tk8);
            Constructor_Tsimbolos tk9 = new Constructor_Tsimbolos(9, ">bool", "Palabra reservada", " Booleano tru or false ");
            tSimbolos.Add(tk9);
            Constructor_Tsimbolos tk10 = new Constructor_Tsimbolos(10, "-", "Operador", " Representa una resta ");
            tSimbolos.Add(tk10);
            Constructor_Tsimbolos tk11 = new Constructor_Tsimbolos(11, "+", "Operador", " Representa una suma ");
            tSimbolos.Add(tk11);
            Constructor_Tsimbolos tk12 = new Constructor_Tsimbolos(12, "*", "Operador", " Representa una multiplicacion ");
            tSimbolos.Add(tk12);
            Constructor_Tsimbolos tk13 = new Constructor_Tsimbolos(13, "/", "Operador", " Representa una division ");
            tSimbolos.Add(tk13);
            Constructor_Tsimbolos tk14 = new Constructor_Tsimbolos(14, ":", "Operador", " Simbolo de asignacion ");
            tSimbolos.Add(tk14);
            Constructor_Tsimbolos tk15 = new Constructor_Tsimbolos(15, ">", "Operador", " Mayor que ");
            tSimbolos.Add(tk15);
            Constructor_Tsimbolos tk16 = new Constructor_Tsimbolos(16, "<", "Operador", " Menor que ");
            tSimbolos.Add(tk16);
            Constructor_Tsimbolos tk17 = new Constructor_Tsimbolos(17, ">:", "Operador", " Mayor o igual que ");
            tSimbolos.Add(tk17);
            Constructor_Tsimbolos tk18 = new Constructor_Tsimbolos(18, "<:", "Operador", " Menor o igual que ");
            tSimbolos.Add(tk18);
            Constructor_Tsimbolos tk19 = new Constructor_Tsimbolos(19, "&&", "Operador logico", " Condicion esto y esto ");
            tSimbolos.Add(tk19);
            Constructor_Tsimbolos tk20 = new Constructor_Tsimbolos(20, "||", "Operador logico", " Condicion esto o esto ");
            tSimbolos.Add(tk20);
            Constructor_Tsimbolos tk21 = new Constructor_Tsimbolos(21, "::", "Operador logico", " Condicion esto es igual a esto ");
            tSimbolos.Add(tk21);
            Constructor_Tsimbolos tk22 = new Constructor_Tsimbolos(22, "!:", "Operador logico", " Condicion diferente a ");
            tSimbolos.Add(tk22);
            Constructor_Tsimbolos tk23 = new Constructor_Tsimbolos(23, "!", "Operador logico", " Condicion de negacion ");
            tSimbolos.Add(tk23);
            Constructor_Tsimbolos tk24 = new Constructor_Tsimbolos(24, ">print", "Palabra reservada", " Muestra en consola ");
            tSimbolos.Add(tk24);
            Constructor_Tsimbolos tk25 = new Constructor_Tsimbolos(25, ">read", "Palabra reservada", " captura un valor desde consola ");
            tSimbolos.Add(tk25);
            Constructor_Tsimbolos tk26 = new Constructor_Tsimbolos(26, ">func", "Palabra reservada", " Define una funcion ");
            tSimbolos.Add(tk26);
            Constructor_Tsimbolos tk27 = new Constructor_Tsimbolos(27, ">class", "Palabra reservada", " define una clase ");
            tSimbolos.Add(tk27);
            Constructor_Tsimbolos tk28 = new Constructor_Tsimbolos(28, ">si", "Palabra reservada", " si tal condicion se cumple ");
            tSimbolos.Add(tk28);
            Constructor_Tsimbolos tk29 = new Constructor_Tsimbolos(29, ">sino", "Palabra reservada", " si tal condicion no se cumple ");
            tSimbolos.Add(tk29);
            Constructor_Tsimbolos tk30 = new Constructor_Tsimbolos(30, "(", "Parametro", " Inicia peticion de parametro ");
            tSimbolos.Add(tk30);
            Constructor_Tsimbolos tk31 = new Constructor_Tsimbolos(31, ")", "Parametro", " Finaliza peticion de parametro ");
            tSimbolos.Add(tk31);
            Constructor_Tsimbolos tk32 = new Constructor_Tsimbolos(32, "~", "Concatenacion", " Permite concatenar variables ");
            tSimbolos.Add(tk32);
            Constructor_Tsimbolos tk33 = new Constructor_Tsimbolos(33, "'", "Indicador de texto", " Indica donde comienza y termina un string ");
            tSimbolos.Add(tk33);
        }

        public List<Constructor_Tsimbolos> ObtenerTokens()
        {
            return tSimbolos;
        }

        public List<Complete> BuscarToken(string argumento, int linea, string regla)
        {
            foreach (var word in tSimbolos)
            {
                if (word.Token1 == argumento)
                {
                    if(Verificar((linea+1).ToString()) == true)
                    {
                        return datos;
                    }
                    else
                    {
                        datos.Add(new Complete(word.Token1, word.Tipo1, (linea + 1).ToString(), word.ID_Token1.ToString(), regla, word.Descripcion_Tipo1));
                        return datos;
                    }
                }
            }
            return null;
        }

        private bool Verificar(string linea)
        {
            foreach(var x in datos)
            {
                if(x.Linea == linea)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
