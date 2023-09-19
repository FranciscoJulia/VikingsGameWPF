using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikingsGameWPF
{
    public class VikingPlayer
    {
		public VikingPlayer() 
		{
            tipo = "Agricultor";
            monedas = 0;
            experiencia = 0;
            lealtad = 0;
			vida = 100;
			HachaNormal = true;
			EscudoMadera = true;
			EspadaBronce = true;
			CasaChoza = true;
			ComidaPan = true;
        }


		//HACHAS
        public bool HachaNormal { get; set; }
        public bool HachaDoble { get; set; }
		public bool HachaPico { get; set; }
		//ESPADAS
		public bool EspadaBronce { get; set; }
        public bool EspadaHierro { get; set; }
        public bool EspadaAcero { get; set; }
		//ESCUDOS
        public bool EscudoMadera { get; set; }
        public bool EscudoReforzado { get; set; }
        public bool EscudoUltimum { get; set; }
		//CASAS
        public bool CasaChoza { get; set; }
        public bool CasaPequeña { get; set; }
        public bool CasaMansion { get; set; }
        public bool CasaMansionPiedra{ get; set; }
		//COMIDAS
        public bool ComidaPan { get; set; }
        public bool ComidaPescado { get; set; }
        public bool ComidaPollo { get; set; }
        public bool ComidaFestin { get; set; }


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
		private int vida;
		public int Vida
		{
			get { return vida; }
			set { vida = value; }
		}




	}
}
