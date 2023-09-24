using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VikingsGameWPF
{
    public class VikingPlayer
    {
		public VikingPlayer() 
		{
            tipo = "Agricultor";
            monedas = 5000;
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
        public void MaxVida()
        {
            if (CasaChoza == true) maxVida = 100;
            else if (CasaPequeña == true) maxVida = 500;
            else if (CasaMansion == true) maxVida = 2000;
            else if (CasaMansionPiedra == true) maxVida = 4000;
        }
        
        private int minVida = 0;

        public int sumaVidaComida = 0;
        public void SumaVidaElementos()
        {
            //VIDA DE COMIDAS
            if (ComidaPan) sumaVidaComida = 5;
            else if (ComidaPescado) sumaVidaComida = 25;
            else if (ComidaPollo) sumaVidaComida = 60;
            else if (ComidaFestin) sumaVidaComida = 150;
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

        private int minExp = 0;

        public int sumaExpHacha = 0;
        public int sumaExpEspada = 0;
        public int sumaExpEscudo = 0;
        public void SumaExpElementos()
        {
            sumaExpHacha = 0;
            sumaExpEspada = 0;
            sumaExpEscudo = 0;
            //EXP DE HACHAS
            if (HachaNormal) sumaExpHacha = 1;
            else if (HachaPico) sumaExpHacha = 20;
            else if (HachaDoble) sumaExpHacha = 45;

            //EXP DE ESPADAS
            if (EspadaBronce) sumaExpEspada = 1;
            else if (EspadaHierro) sumaExpEspada = 20;
            else if (EspadaAcero) sumaExpEspada = 45;

            //EXP ESCUDOS
            if (EscudoMadera) sumaExpEscudo = 1;
            else if (EscudoReforzado) sumaExpEscudo = 20;
            else if (EscudoUltimum) sumaExpEscudo = 45;
        }
        public void GanarExp(int cantExpGanada)
        {
            experiencia += cantExpGanada;
        }
        public void PerderExp(int cantExpPerdida)
        {
            if (experiencia - cantExpPerdida < minExp) experiencia = 0;
            else experiencia -= cantExpPerdida;
        }
        public int sumaExp { get; set; }    
        public void SumaExp()
        {
            sumaExp = 0;
            sumaExp += sumaExpHacha;
            sumaExp += sumaExpEspada;
            sumaExp += sumaExpEscudo;
        }
        public void RestaExp()
        {

        }
        //-------------------------//


        public int cantPoder { get; set; }
        public int sumaPoderHacha = 0;
        public int sumaPoderEspada = 0;
        public int sumaPoderEscudo = 0;
        public void CantPoder()
        {
            cantPoder = 0;

            //PODER DE HACHAS
            if (HachaNormal) sumaPoderHacha = 10;
            else if (HachaPico) sumaPoderHacha = 30;
            else if (HachaDoble) sumaPoderHacha = 100;

            //PODER DE ESPADAS
            if (EspadaBronce) sumaPoderEspada = 10;
            else if (EspadaHierro) sumaPoderEspada = 30;
            else if (EspadaAcero) sumaPoderEspada = 100;

            //PODER ESCUDOS
            if (EscudoMadera) sumaPoderEscudo = 10;
            else if (EscudoReforzado) sumaPoderEscudo = 30;
            else if (EscudoUltimum) sumaPoderEscudo = 100;


            cantPoder += sumaPoderHacha;
            cantPoder += sumaPoderEspada;
            cantPoder += sumaPoderEscudo;
        }
        //PODER
        private int poder;
        public int Poder
        {
            get { return poder; }
            set { poder = value; }
        }

        //private int minPoder = 0;

        ////public int sumaPoderHacha = 0;
        ////public int sumaPoderEspada = 0;
        ////public int sumaPoderEscudo = 0;
        //public void SumaPoderElementos()
        //{
        //    //PODER DE HACHAS
        //    if (HachaNormal) sumaPoderHacha = 10;
        //    else if (HachaPico) sumaPoderHacha = 30;
        //    else if (HachaDoble) sumaPoderHacha = 100;

        //    //PODER DE ESPADAS
        //    if (EspadaBronce) sumaPoderEspada = 10;
        //    else if (EspadaHierro) sumaPoderEspada = 30;
        //    else if (EspadaAcero) sumaPoderEspada = 100;

        //    //PODER ESCUDOS
        //    if (EscudoMadera) sumaPoderEscudo = 10;
        //    else if (EscudoReforzado) sumaPoderEscudo = 30;
        //    else if (EscudoUltimum) sumaPoderEscudo = 100;
        //}
        //public void GanarPoder(int cantPoderGanado)
        //{
        //    poder += cantPoderGanado;
        //}
        //public void PerderPoder(int cantPoderPerdido)
        //{
        //    if (poder - cantPoderPerdido < minPoder) poder = 0;
        //    else poder -= cantPoderPerdido;
        //}
        //public int sumaPoder { get; set; }
        //public void SumaPoder()
        //{
        //    sumaPoder = 0;
        //    sumaPoder += sumaPoderHacha;
        //    sumaPoder += sumaPoderEspada;
        //    sumaPoder += sumaPoderEscudo;

        //    GanarPoder(sumaPoder);
        //}
        //public void RestaPoder()
        //{

        //}
        //-------------------//


        //MONEDAS
        private int monedas;
        public int Monedas
        {
            get { return monedas; }
            set { monedas = value; }
        }

        private int minMonedas = 0;

        public int restaMonedasHacha = 0;
        public int restaMonedasEspada = 0;
        public int restaMonedasEscudo = 0;
        public void RestaMonedasElementos()
        {
            restaMonedasHacha = 0;
            restaMonedasEspada = 0;
            restaMonedasEscudo = 0;
            //EXP DE HACHAS
            if (HachaNormal) restaMonedasHacha = 0;
            else if (HachaPico) restaMonedasHacha = 40;
            else if (HachaDoble) restaMonedasHacha = 100;

            //EXP DE ESPADAS
            if (EspadaBronce) restaMonedasEspada = 0;
            else if (EspadaHierro) restaMonedasEspada = 40;
            else if (EspadaAcero) restaMonedasEspada = 100;

            //EXP ESCUDOS
            if (EscudoMadera) restaMonedasEscudo = 0;
            else if (EscudoReforzado) restaMonedasEscudo = 40;
            else if (EscudoUltimum) restaMonedasEscudo = 100;
        }
        public void GanarMonedas(int cantMonedaGanada)
        {
            monedas += cantMonedaGanada;
        }
        public void PerderMonedas(int cantMonedaPerdida)
        {
            if (monedas - cantMonedaPerdida <= minMonedas) 
            {
                resetElementos();
                monedas = 0;
            }
            else monedas -= cantMonedaPerdida;
        }
        public int restaMonedas { get; set; }
        public void RestaMonedas()
        {
            restaMonedas = 0;
            restaMonedas += restaMonedasHacha;
            restaMonedas += restaMonedasEspada;
            restaMonedas += restaMonedasEscudo;
        }

        private void resetElementos()
        {
            HachaNormal = true;
            HachaPico = false;
            HachaDoble = false;

            EspadaBronce = true;
            EspadaHierro = false;
            EspadaAcero = false;

            EscudoMadera = true;
            EscudoReforzado = false;
            EscudoUltimum = false;
        }

        public void revisaArmamento() // revisa si el jugador aún tiene el dinero para utilizar el arma
        {
            if(monedas < 40)
            {
                HachaNormal = true;
                HachaPico = false;
                HachaDoble = false;

                EspadaBronce = true;
                EspadaHierro = false;
                EspadaAcero = false;

                EscudoMadera = true;
                EscudoReforzado = false;
                EscudoUltimum = false;
            }else if (monedas <= 80)
            {

            }
        }
    }
}
