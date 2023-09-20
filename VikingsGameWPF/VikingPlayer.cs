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
            poder = 0;
			vida = 100;
			maxVida = 100;
			HachaNormal = true;
			EscudoMadera = true;
			EspadaBronce = true;
			CasaChoza = true;
			ComidaPan = true;
			dia = 1;
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
		
		
        private int poder;
        public int Poder
        {
            get { return poder; }
            set { poder = value; }
        }
		
		//DIA
		private int dia;	
		public int Dia
		{
			get { return dia; }
			set { dia = value; }
		}
		//-------------//



		

		//VIDA
        private int vida;
        public int Vida
        {
            get { return vida; }
            set { vida = value; }
        }
        private int maxVida;
        public int MaxVida
        {
            get { return maxVida; }
            set { maxVida = value; }
        }
        private int minVida = 0;

        public int sumaVidaComida = 0;
        public void SumaVidaElementos()
        {
            if (ComidaPan) sumaVidaComida = 5;
            else if (ComidaPescado) sumaVidaComida = 20;
            else if (ComidaPollo) sumaVidaComida = 45;
            else if (ComidaFestin) sumaVidaComida = 100;

            //if()
        }

        public void GanarVida(int cantVidaGanada)
		{
			if(vida + cantVidaGanada >= maxVida)
			{
				vida = maxVida;
			}else
			{
				vida += cantVidaGanada;
			}
		}
        public void PerderVida(int cantVidaPerdida)
        {
            if(vida - cantVidaPerdida < minVida)
            {
                vida = 0;
            }else
            {
                vida -= cantVidaPerdida;
            }
        }
		
        public int sumaVida { get; set; }
        public void SumaVida()
		{
			sumaVida = 0;
			sumaVida += sumaVidaComida;

			GanarVida(sumaVida);
		}
        public void RestaVida()
        {

        }
        //-------------//


        //EXPERIENCIA
        private int experiencia;
        public int Experiencia
        {
            get { return experiencia; }
            set { experiencia = value; }
        }

        public int sumaExpComida = 0;
        public void SumaExpElementos()
        {
            if (ComidaPan) sumaExpComida = 5;
            else if (ComidaPescado) sumaExpComida = 20;
            else if (ComidaPollo) sumaExpComida = 45;
            else if (ComidaFestin) sumaExpComida = 100;

            //if()
        }






        //MONEDAS
        private int monedas;
        public int Monedas
        {
            get { return monedas; }
            set { monedas = value; }
        }
        private int minMonedas = 0;

        public void GanarMonedas(int cantMonedaGanada)
        {
            monedas += cantMonedaGanada;
        }
        public void PerderMonedas(int cantMonedaPerdida)
        {
            if (monedas - cantMonedaPerdida < minMonedas)
            {
                monedas = 0;
            }
            else
            {
                monedas -= cantMonedaPerdida;
            }
        }
    }
}
