using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikingsGameWPF
{
    internal class Vikingo
    {
        public Vikingo(string Nombre)
        {
            nombre = Nombre;
            tipo = "Agricultor";
            monedas = 0;
            experiencia = 0;
            lealtad = 0;
        }

        //PROPIEDADES DEL VIKINGO
        private int id;
        private string nombre;
        private string tipo;
        private int monedas, experiencia, lealtad;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public int Monedas
        {
            get { return monedas; }
            set { monedas = value; }
        }
        public int Experiencia
        {
            get { return experiencia; }
            set { experiencia = value; }
        }
        public int Lealtad
        {
            get { return lealtad; }
            set { lealtad = value; }
        }
    }
}
