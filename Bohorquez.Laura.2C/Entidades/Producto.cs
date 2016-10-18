using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public abstract class Producto
    {
        #region ATRIBUTOS

        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        #endregion

        #region PROPIEDADES

        public abstract float CalcularCostoDeProduccion
        {
            get;
        }
       
        public EMarcaProducto Marca
        {
            get { return this._marca; }
        }
        public float Precio
        {
            get { return this._precio; }
        }

        #endregion

        #region CONSTRUCTOR

        public Producto(int codigoDeBarra, float precio, EMarcaProducto marca)
        {
            this._codigoDeBarra = codigoDeBarra;
            this._precio = precio;
            this._marca = marca;
            
        }

        #endregion

        #region METODOS

        public virtual string Consumir()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Parte de la mezcla");
            //return sb.ToString();

            return "Parte de una mezcla";

        }

        public override bool Equals(object obj)
        {
            if (obj is Producto)
            {
                return true;
            }
           
            return false;
        
        }

        public static explicit operator int  (Producto p)
        {
            return p._codigoDeBarra;
        }

        public static implicit operator string(Producto p)
        {
           // return ("Codigo de Barra: " + p._codigoDeBarra + ", Marca: " + p._marca + ", Precio: " + p._precio);
            return MostrarProducto(p);
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CODIGO DE BARRA: "+ p._codigoDeBarra);
            sb.AppendLine("MARCA: " + p._marca);
            sb.AppendLine("PRECIO: " + p._precio);
            return sb.ToString();
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }

        public static bool operator ==(Producto proUno, EMarcaProducto marca)
        {
          return (proUno._marca == marca);
        }
        public static bool operator !=(Producto proUno, Producto proDos)
        {
            return !(proUno == proDos);
        }

        public static bool operator ==(Producto proUno, Producto proDos)
        {
            return (proUno.Equals(proDos) && proUno._codigoDeBarra == proDos._codigoDeBarra && proUno._marca == proDos._marca);
        }

        #endregion


        public enum EMarcaProducto
        {
            Diversión, Pitusas, Favorita, Naranjú, Swift
        }
        public enum ETipoProducto
        {
            Harina, Jugo, Gaseosa, Galletita, Todos
        }

    }
}
