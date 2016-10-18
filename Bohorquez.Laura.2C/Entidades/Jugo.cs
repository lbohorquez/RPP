using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo:Producto
    {
        #region ATRIBUTOS

        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        #endregion

        #region PROPIEDADES

        public override float CalcularCostoDeProduccion
        {
            get { return (this._precio*(float)0.40);}
        }

        #endregion

        #region CONSTRUCTORES

        static Jugo() 
        {
            DeConsumo = true;          
        }

        public Jugo(int codigo, float precio, EMarcaProducto marca, ESaborJugo sabor)
            : base(codigo, precio, marca)
        {
            this._sabor = sabor;
        }

        #endregion

        #region METODOS

        public override string Consumir()
        {
            return "Bebible";
        }

        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: "+base._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + base._codigoDeBarra.ToString());
            sb.AppendLine("PRECIO: " + base._precio.ToString());
            sb.AppendLine("SABOR: " + this._sabor.ToString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarJugo().ToString();
        }


        #endregion

        public enum ESaborJugo
        {
            Pasable, Asqueroso
        }
    }
}
