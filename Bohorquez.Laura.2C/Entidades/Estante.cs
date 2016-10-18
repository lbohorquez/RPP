using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;



namespace Entidades
{
    public class Estante
    {
        #region ATRIBUTOS

        protected sbyte _capacidad;
        protected List<Producto> _productos;

        #endregion

        #region PROPIEDAD

        public float ValorEstanteTotal
        {
            get
            {
                // float valor = 0;
                // valor= (GetValorEstante(ETipoProducto.Galletita)+GetValorEstante(ETipoProducto.Gaseosa)+GetValorEstante(ETipoProducto.Jugo)+GetValorEstante(ETipoProducto.Harina));
                //return valor;
                return (GetValorEstante());
            }
        }

        #endregion

        #region CONSTRUCTOR

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }

        #endregion

        #region METODOS

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        private float GetValorEstante()
        {
            return GetValorEstante(Producto.ETipoProducto.Todos);
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float valor = 0;


            foreach (Producto p in this._productos)
            {
                if (tipo == Producto.ETipoProducto.Galletita && p is Galletita)
                {
                    valor = +(((Galletita)p).Precio);
                }
                if (tipo == Producto.ETipoProducto.Gaseosa && p is Gaseosa)
                {
                    valor = +(((Gaseosa)p).Precio);
                }
                if (tipo == Producto.ETipoProducto.Jugo && p is Jugo)
                {
                    valor = +(((Jugo)p).Precio);
                }
                if (tipo == Producto.ETipoProducto.Harina && p is Harina)
                {
                    valor = +(((Harina)p).Precio);
                }
         
                if (tipo == Producto.ETipoProducto.Todos)
                {
                    valor = + p.Precio;
                }

            }
            return valor;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CAPACIDAD: " + e._capacidad.ToString());
            foreach (Producto p in e._productos)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto prod)
        {
            foreach (Producto p in e._productos)
            {
                if (p == prod)
                {
                    return true;
                    
                }
            }

            return false;
        }

        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }

        public static Estante operator -(Estante e, Producto prod)
        {
            if (e == prod)
            {
                e._productos.Remove(prod);
                return e;
            }

            return e;
        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            foreach (Producto p in e._productos)
            {
                if (p.Equals(tipo))
                {
                    e._productos.Remove(p);
                    return e;
                }
            }

            return e;
            

        }

        public static bool operator +(Estante e, Producto prod)
        {
            //   for (int i = 0; i > e._capacidad; i++)
            if (e._capacidad >= e._productos.Count() && e != prod)
            {
                    e._productos.Add(prod);
                    return true;
          
            }
            return false;
        }


        #endregion

        //public static bool GuardarEstante(Estante e)
        //{
        //    StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiArchivo.txt", true);
        //    sw.WriteLine("ESTANTE");
        //    sw.WriteLine("Capacidad" + e._capacidad);
        //    foreach (Producto p in e._productos)
        //    {
        //        sw.WriteLine(p.ToString());
        //    }            
        //    return true;
        //}

        //public static bool DeserializarEstante(Estante e)
        //{
        //    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiarchivoXML.xml"))
        //    {
        //        XmlTextReader TR = new XmlTextReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiarchivoXML.xml");
        //        XmlSerializer TS = new XmlSerializer(typeof(Estante));

        //        e = new Estante();
        //        e = (Estante)TS.Deserialize(TR);
        //        Console.WriteLine("---------- Serializo ------------- ");
        //        Console.WriteLine ("Capacidad: " + e._capacidad);
        //        foreach (Producto p in e._productos)
        //        {
        //            Console.WriteLine(p.ToString());
        //        }
        //        TR.Close();
        //    }
        //    return true;
        //}

        //public static bool SerializarEstante(Estante e)
        //{
        //    XmlTextWriter XG = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiarchivoXML.xml", Encoding.UTF8);
        //    XmlSerializer XS = new XmlSerializer(typeof(Estante));
           
        //    XS.Serialize(XG, e); //this este objeto

        //    XG.Close();

        //    return true;
        //}
    }
}
