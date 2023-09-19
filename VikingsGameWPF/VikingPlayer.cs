using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikingsGameWPF
{
    public class VikingPlayer
    {
        public VikingPlayer(string nombre) 
		{
			this.nombre = nombre;
			tipo = "Agricultor";
			monedas = 0;
			experiencia = 0;
			lealtad = 0;
		}

		public VikingPlayer() 
		{
            tipo = "Agricultor";
            monedas = 0;
            experiencia = 0;
            lealtad = 0;
			HachaNormal = true;
			EscudoMadera = true;
			EspadaBronce = true;
        }



        public bool HachaNormal { get; set; }
        public bool HachaDoble { get; set; }
        public bool HachaPico { get; set; }
        public bool EspadaBronce { get; set; }
        public bool EspadaHierro { get; set; }
        public bool EspadaAcero { get; set; }
        public bool EscudoMadera { get; set; }
        public bool EscudoReforzado { get; set; }
        public bool EscudoUltimum { get; set; }	


        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private string tipo;	
		public string Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}
		private int monedas;
		public int Monedas
		{
			get { return monedas; }
			set { monedas = value; }
		}
		private int experiencia;
		public int Experiencia
		{
			get { return experiencia; }
			set { experiencia = value; }
		}
        private int lealtad;
        public int Lealtad
        {
            get { return lealtad; }
            set { lealtad = value; }
        }	




    }
}
