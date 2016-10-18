using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa:Producto
    {
       
        #region ATRIBUTOS
       
        protected float _litros;
        protected static bool DeConsumo;

        #endregion

        #region PROPIEDADES

        public override float CalcularCostoDeProduccion
        {

            get { return (this._precio * (float)0.42); }
        }

        #endregion

        #region CONSTRUCTOR

        static Gaseosa()
        {
            DeConsumo = true;
        }

        public Gaseosa(int codigo, float precio, EMarcaProducto marca, float litros)
            : base(codigo, precio, marca)
        {
            this._litros=litros;
        }
        public Gaseosa(Producto p, float litros):this(0, p.Precio, p.Marca, litros) //VFR
        {
        }

        #endregion

        #region METODOS

        public override string Consumir()
        {
            return "Bebible";
        }

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + this._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + this._codigoDeBarra.ToString());
            sb.AppendLine("PRECIO: " + this._precio.ToString());
            sb.AppendLine("LITROS: " + this._litros);

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGaseosa().ToString();
        }


        #endregion
    }
}
