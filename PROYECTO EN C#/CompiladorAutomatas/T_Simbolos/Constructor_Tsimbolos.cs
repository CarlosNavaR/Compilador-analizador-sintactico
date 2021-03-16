using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Simbolos
{
    public class Constructor_Tsimbolos
    {
        private int ID_Token;
        private string Token;
        private string Tipo;
        private string Descripcion_Tipo;

        public Constructor_Tsimbolos(int iD_Token, string token, string tipo, string descripcion_Tipo)
        {
            ID_Token1 = iD_Token;
            Token1 = token;
            Tipo1 = tipo;
            Descripcion_Tipo1 = descripcion_Tipo;
        }

        public int ID_Token1 { get => ID_Token; set => ID_Token = value; }
        public string Token1 { get => Token; set => Token = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string Descripcion_Tipo1 { get => Descripcion_Tipo; set => Descripcion_Tipo = value; }

    }
}