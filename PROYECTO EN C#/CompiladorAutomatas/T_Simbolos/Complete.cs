using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Simbolos
{
    public class Complete
    {
        private string token;
        private string tipo;
        private string linea;
        private string idTk;
        private string Regla;
        private string Descripcion;

        public Complete()
        {
        }

        public Complete(string token, string tipo, string linea, string idTk,string Regla, string Descripcion)
        {
            this.token = token;
            this.tipo = tipo;
            this.linea = linea;
            this.idTk = idTk;
            this.Regla1 = Regla;
            this.Descripcion1 = Descripcion;
        }

        public string Token { get => token; set => token = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Linea { get => linea; set => linea = value; }
        public string IdTk { get => idTk; set => idTk = value; }
        public string Regla1 { get => Regla; set => Regla = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    }
}
