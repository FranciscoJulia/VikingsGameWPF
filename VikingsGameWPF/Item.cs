using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace VikingsGameWPF
{
    internal class Item
    {
       //CONSTRUCTOR GENERAL
        public Item(string nombre, int precio, string descripcion, int xp, int lealtad, int svida, int rvida)
		{
			this.nombre = nombre;
			this.precio = precio;
			this.descripcion = descripcion;
			this.xp = xp;
			this.lealtad = lealtad;
			this.sVida = svida;
			this.rVida = rvida;
		}

		//CONSTRUCTOR COMIDAS
		public Item(string nombre, int precio, string descripcion, int svida)
		{
			this.nombre = nombre;
			this.precio = precio;
			this.descripcion = descripcion;
			this.sVida = svida;
		}

		//CONSTRUCTOR CASAS
		private int reservaVida;

		public int ReservaVida
		{
			get { return reservaVida; }
			set { reservaVida = value; }
		}	

		public Item(string nombre, int precio, string descripcion, int xp, int reservaVida)
		{
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
			this.xp = xp;
			this.reservaVida = reservaVida;
        }




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
		private int precio;

		public int Precio
		{
			get { return precio; }
			set { precio = value; }
		}
		private int xp;
		public int XP
		{
			get { return xp; }
			set { xp = value; }
		}
		private int lealtad;
		public int Lealtad
		{
			get { return lealtad; }
			set { lealtad = value; }
		}
		private string descripcion;
		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
		private int sVida;	
		public int SVida
		{
			get { return sVida; }
			set { sVida = value; }
		}
        private int rVida;
        public int RVida
        {
            get { return rVida; }
            set { rVida = value; }
        }






    }
}
