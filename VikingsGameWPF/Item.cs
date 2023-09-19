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
		public Item(string nombre, int precio, string descripcion, int xp, int lealtad)
		{
			this.nombre = nombre;
			this.precio = precio;
			this.descripcion = descripcion;
			this.xp = xp;
			this.lealtad = lealtad;
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





	}
}
